using BingoAPI.Events;
using BingoAPI.Goals;
using BingoAPI.Models;
using BingoAPI.Models.Settings;
using BingoAPI.Networking;

namespace Silksong.BingoSync;

public enum ClientState
{
	None,
	Disconnected,
	Connected,
	Loading,
}

public class Controller : IDisposable
{
	// --- SINGLETON ---

	/// <summary>
	/// Calls <see cref="GoalTracker.Evaluate()"/> of the current instance
	/// </summary>
	//public static void Evaluate() => Instance?._tracker.Evaluate();

	// --- STATES ---
	public ClientState State { get; private set; } = ClientState.None;

	public Card? Card { get; private set; }

	private readonly GoalPool _pool;
	public readonly EventDispatcher Events;
	private readonly GoalTracker _tracker;
	private readonly Session _session;

	public Controller(GoalPool pool)
	{
		_pool = pool;

		Events = new EventDispatcher();
		SubscribeToEvents(Events);

		_tracker = new GoalTracker();
		_tracker.OnGoalMarked += OnGoalMarked;
		_tracker.OnGoalCleared += OnGoalCleared;

		_session = new Session(Events);
	}

	public async Task UpdateCard()
	{
		Card = await _session.GetCard(_pool);
		OnCardUpdated?.Invoke(Card);
	}

	#region Events

	public delegate void CardCallback(Card? card);

	/// <summary>
	/// Called when <see cref="Card"/> was updated
	/// </summary>
	public event CardCallback? OnCardUpdated;

	#endregion

	#region Callbacks

	/// <summary>
	/// Subscribes this controller to the given <see cref="EventDispatcher"/>
	/// </summary>
	private void SubscribeToEvents(EventDispatcher events)
	{
		events.OnSelfSquareMarked += OnSquareMarked;
		events.OnOtherSquareMarked += OnSquareMarked;
		events.OnSelfSquareCleared += OnSquareCleared;
		events.OnOtherSquareCleared += OnSquareCleared;
		events.OnSelfCardGenerated += OnCardGenerated;
		events.OnOtherCardGenerated += OnCardGenerated;
	}

	/// <summary>
	/// Unsubscribes this controller from the given <see cref="EventDispatcher"/>
	/// </summary>
	private void UnsubscribeFromEvents(EventDispatcher events)
	{
		events.OnSelfSquareMarked -= OnSquareMarked;
		events.OnOtherSquareMarked -= OnSquareMarked;
		events.OnSelfSquareCleared -= OnSquareCleared;
		events.OnOtherSquareCleared -= OnSquareCleared;
		events.OnSelfCardGenerated -= OnCardGenerated;
		events.OnOtherCardGenerated -= OnCardGenerated;
	}

	private void OnGoalMarked(Goal goal)
	{
		if (Card == null)
			return;

		var indexes = Card.FindByGoal(goal);

		foreach (var index in indexes)
		{
			if (Card.IsMarkedBy(index, _session.Team))
				continue;

			_session.MarkSquare(index);
		}
	}

	private void OnGoalCleared(Goal goal)
	{
		if (Card == null)
			return;

		var indexes = Card.FindByGoal(goal);

		foreach (var index in indexes)
		{
			if (!Card.IsMarkedBy(index, _session.Team))
				continue;

			_session.ClearSquare(index);
		}
	}

	private void OnSquareMarked(Player player, Square square, Team team)
	{
		Card?.Mark(square.Index, team);
		OnCardUpdated?.Invoke(Card);
	}

	private void OnSquareCleared(Player player, Square square, Team team)
	{
		Card?.Unmark(square.Index, team);
		OnCardUpdated?.Invoke(Card);
	}

	private void OnCardGenerated(Player player, bool isHidden)
	{
		Task.Run(UpdateCard);
	}

	#endregion

	#region Actions

	/// <summary>
	/// Joins the room with the given settings
	/// </summary>
	public Task<bool> Join(JoinRoomSettings settings) => _session.JoinRoom(settings);

	/// <summary>
	/// Exits the current room
	/// </summary>
	public Task<bool> Exit() => _session.LeaveRoom();

	/// <summary>
	/// Joins the room with the given settings
	/// </summary>
	public async Task Join(
		string code,
		string nickname,
		string password,
		Team   team
	)
	{
		if (State == ClientState.Loading)
			return;

		State = ClientState.Loading;

		var settings = new JoinRoomSettings
		{
			Code = code,
			Nickname = nickname,
			Password = password,
		};

		var hasJoined = await _session.JoinRoom(settings);

		if (!hasJoined)
		{
			State = ClientState.None;
			return;
		}

		State = ClientState.Connected;

		await _session.ChangeTeam(team);
		await UpdateCard();

		_tracker.Clear();

		if (Card != null)
		{
			foreach (var goal in Card.GetAllGoals())
				_tracker.TryAdd(goal);
		}
	}

	#endregion

	/// <inheritdoc />
	public void Dispose()
	{
		UnsubscribeFromEvents(Events);
		_session.Dispose();
	}
}