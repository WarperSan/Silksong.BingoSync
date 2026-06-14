using BingoAPI.Events;
using BingoAPI.Goals;
using BingoAPI.Models;
using BingoAPI.Models.Settings;
using BingoAPI.Networking;
using Silksong.BingoSync.Helpers;

namespace Silksong.BingoSync;

public class Controller : IDisposable
{
	// --- SINGLETON ---

	/// <summary>
	/// Calls <see cref="GoalTracker.Evaluate()"/> of the current instance
	/// </summary>
	//public static void Evaluate() => Instance?._tracker.Evaluate();

	// --- STATES ---
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

	#region Events

	public delegate void CardCallback(Card? card);

	/// <summary>
	/// Called when <see cref="_card"/> was updated
	/// </summary>
	public event CardCallback? OnCardUpdated;

	#endregion

	#region Callbacks

	/// <summary>
	/// Subscribes this controller to the given <see cref="EventDispatcher"/>
	/// </summary>
	private void SubscribeToEvents(EventDispatcher events)
	{
		events.OnSelfConnected += OnConnected;
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
		events.OnSelfConnected -= OnConnected;
		events.OnSelfSquareMarked -= OnSquareMarked;
		events.OnOtherSquareMarked -= OnSquareMarked;
		events.OnSelfSquareCleared -= OnSquareCleared;
		events.OnOtherSquareCleared -= OnSquareCleared;
		events.OnSelfCardGenerated -= OnCardGenerated;
		events.OnOtherCardGenerated -= OnCardGenerated;
	}

	private void OnConnected(Player player)
	{
		UpdateCard();
		/*_tracker.Clear();

		if (Card != null)
		{
			foreach (var goal in Card.GetAllGoals())
				_tracker.TryAdd(goal);
		}*/
	}

	private void OnGoalMarked(Goal goal)
	{
		if (_card == null)
			return;

		var indexes = _card.FindByGoal(goal);

		foreach (var index in indexes)
		{
			if (_card.IsMarkedBy(index, _session.Team))
				continue;

			_session.MarkSquare(index);
		}
	}

	private void OnGoalCleared(Goal goal)
	{
		if (_card == null)
			return;

		var indexes = _card.FindByGoal(goal);

		foreach (var index in indexes)
		{
			if (!_card.IsMarkedBy(index, _session.Team))
				continue;

			_session.ClearSquare(index);
		}
	}

	private void OnSquareMarked(Player player, Square square, Team team)
	{
		_card?.Mark(square.Index, team);
		OnCardUpdated?.Invoke(_card);
	}

	private void OnSquareCleared(Player player, Square square, Team team)
	{
		_card?.Unmark(square.Index, team);
		OnCardUpdated?.Invoke(_card);
	}

	private void OnCardGenerated(Player player, bool isHidden) => UpdateCard();

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

	#endregion

	#region Card

	private Card? _card;

	private Task<Card?>? _runningCardUpdate;

	private void UpdateCard()
	{
		if (_runningCardUpdate != null && !_runningCardUpdate.IsCompleted)
		{
			Log.Warning($"An update of '{nameof(Card)}' is already pending.");
			return;
		}

		_runningCardUpdate = Task.Run(() => _session.GetCard(_pool));

		_runningCardUpdate.ContinueWith(task =>
		{
			var card = task.Result;

			_card = card;
			OnCardUpdated?.Invoke(_card);
		});
	}

	#endregion

	/// <inheritdoc />
	public void Dispose()
	{
		UnsubscribeFromEvents(Events);
		_session.Dispose();
	}
}