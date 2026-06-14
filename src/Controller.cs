using BingoAPI.Events;
using BingoAPI.Goals;
using BingoAPI.Models;
using BingoAPI.Models.Settings;
using BingoAPI.Networking;
using JetBrains.Annotations;

namespace Silksong.BingoSync;

public enum ClientState
{
	None,
	Disconnected,
	Connected,
	Loading,
}

internal class Controller : IDisposable
{
	// --- SINGLETON ---
	public static Controller? Instance { get; private set; }

	/// <summary>
	/// Creates a new instance of <see cref="Controller"/>
	/// </summary>
	public static void Create(GoalPool pool)
	{
		Instance?.Dispose();

		Instance = new Controller(pool);
	}

	/// <summary>
	/// Calls <see cref="GoalTracker.Evaluate()"/> of the current instance
	/// </summary>
	public static void Evaluate() => Instance?._tracker.Evaluate();

	// --- STATES ---
	public ClientState State { get; private set; } = ClientState.None;

	public Card? Card { get; private set; }

	public bool IsCardRevealed { get; private set; }

	private readonly GoalPool _pool;
	public readonly EventDispatcher Events;
	private readonly GoalTracker _tracker;
	private readonly Session _session;

	private Controller(GoalPool pool)
	{
		_pool = pool;

		Events = new EventDispatcher();
		Events.OnSelfSquareMarked += OnSquareMarked;
		Events.OnOtherSquareMarked += OnSquareMarked;
		Events.OnSelfSquareCleared += OnSquareCleared;
		Events.OnOtherSquareCleared += OnSquareCleared;
		Events.OnSelfCardRevealed += OnCardRevealed;
		Events.OnOtherCardRevealed += OnCardRevealed;
		Events.OnSelfCardGenerated += async (_,  _) => await UpdateCard();
		Events.OnOtherCardGenerated += async (_, _) => await UpdateCard();

		_tracker = new GoalTracker();
		_tracker.OnGoalMarked += OnGoalMarked;
		_tracker.OnGoalCleared += OnGoalCleared;

		_session = new Session(Events);
	}

	public void RevealCard()
	{
		if (Card == null)
			return;

		if (IsCardRevealed)
			return;

		_session.RevealCard();
	}

	public async Task JoinRoom(
		string roomID,
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
			Code = roomID,
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

	public async Task ExitRoom()
	{
		await _session.LeaveRoom();
		State = ClientState.Disconnected;
	}

	public async Task UpdateCard()
	{
		Card = await _session.GetCard(_pool);
		OnCardUpdated?.Invoke(Card);
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

	private void OnCardRevealed(Player player)
	{
		IsCardRevealed = true;
	}

	#region Events

	public delegate void CardCallback(Card? card);

	/// <summary>
	/// Called when <see cref="Card"/> was updated
	/// </summary>
	public event CardCallback? OnCardUpdated;

	#endregion

	/// <inheritdoc />
	public void Dispose()
	{
		_session.Dispose();
	}
}