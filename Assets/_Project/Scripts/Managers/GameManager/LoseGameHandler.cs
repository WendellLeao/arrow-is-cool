public sealed class LoseGameHandler : GameManager
{
	protected override void AddEventListeners()
	{
		_globalGameEvents.OnPlayerDied += delegate { StopGame(GameState.LOSE); };
	}

	protected override void RemoveEventListeners()
	{
		_globalGameEvents.OnPlayerDied -= delegate { StopGame(GameState.LOSE); };
	}
}
