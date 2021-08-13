using UnityEngine;

public sealed class PauseGameHandler : GameManager
{
	[Header("Pause Game")]
	private bool _canPauseGame = false;

	protected override void OnEnable()
	{
		_globalGameEvents.OnGameIsStarted += AddEventListeners;
	}

	protected override void AddEventListeners()
	{
		_globalGameEvents.OnGameStateChanged += OnGameStateChanged_CheckIfCanPause;

		_globalGameEvents.OnGameIsPaused += OnGameIsPaused_HandlePauseGame;

		_localGameEvents.OnReadPlayerInputs += OnPressPause_HandlePauseGame;
	}

	protected override void RemoveEventListeners()
	{
		_globalGameEvents.OnGameStateChanged -= OnGameStateChanged_CheckIfCanPause;

		_globalGameEvents.OnGameIsPaused -= OnGameIsPaused_HandlePauseGame;

		_localGameEvents.OnReadPlayerInputs -= OnPressPause_HandlePauseGame;
		
		_globalGameEvents.OnGameIsStarted -= AddEventListeners;
	}

	protected override void ResumeGame()
	{
		base.ResumeGame();

		_canPauseGame = false;
	}

	private void OnGameStateChanged_CheckIfCanPause(GameState gameState)
	{
		if (gameState == GameState.LOSE || gameState == GameState.LEVEL_COMPLETED)
		{
			_globalGameEvents.OnGameIsPaused -= OnGameIsPaused_HandlePauseGame;

			_localGameEvents.OnReadPlayerInputs -= OnPressPause_HandlePauseGame;
		}
	}

	private void OnPressPause_HandlePauseGame(PlayerInputsData playerInputData)
	{
		if (playerInputData.PressPause)
		{
			_canPauseGame = !_canPauseGame;

			OnGameIsPaused_HandlePauseGame(_canPauseGame);

			_globalGameEvents.OnGameIsPaused?.Invoke(_canPauseGame);
		}
	}

	private void OnGameIsPaused_HandlePauseGame(bool canPauseGame)
	{
		if (canPauseGame)
		{
			StopGame(GameState.PAUSED);
		}
		else
		{
			ResumeGame();
		}
	}
}
