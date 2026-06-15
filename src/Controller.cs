using BingoAPI.Events;
using BingoAPI.Goals;
using BingoAPI.Models;
using BingoAPI.Models.Settings;
using BingoAPI.Networking;
using Silksong.BingoSync.Helpers;

namespace Silksong.BingoSync;

public class Controller : IDisposable
{
	private readonly GoalPool _pool;

	public readonly EventDispatcher Events;
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

	private void OnConnected(Player player) => UpdateCard();

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
		_card?.Mark(square.Slot.Index, team);
		OnCardUpdated?.Invoke(_card);
	}

	private void OnSquareCleared(Player player, Square square, Team team)
	{
		_card?.Unmark(square.Slot.Index, team);
		OnCardUpdated?.Invoke(_card);
	}

	private void OnCardGenerated(Player player, bool isHidden) => UpdateCard();

	#endregion

	#region Actions

	/// <summary>
	/// Current team
	/// </summary>
	public Team Team => _session.Team;

	/// <summary>
	/// Joins the room with the given settings
	/// </summary>
	public Task<bool> Join(JoinRoomSettings settings) => _session.JoinRoom(settings);

	/// <summary>
	/// Exits the current room
	/// </summary>
	public Task<bool> Exit() => _session.LeaveRoom();

	/// <summary>
	/// Changes team
	/// </summary>
	public Task<bool> SetTeam(Team team) => _session.ChangeTeam(team);

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

			_tracker.Clear();

			if (card != null)
			{
				foreach (var goal in card.GetAllGoals())
					_tracker.TryAdd(goal);
			}

			_card = card;
			OnCardUpdated?.Invoke(_card);
		});
	}

	#endregion

	#region Tracker

	private readonly GoalTracker _tracker;

	/// <summary>
	/// Evaluates every tracked <see cref="Goal"/> for updates
	/// </summary>
	public void Evaluate() => _tracker.Evaluate();

	#endregion

	/// <inheritdoc />
	public void Dispose()
	{
		UnsubscribeFromEvents(Events);
		_session.Dispose();
	}
}