using System;
using System.Collections;
using UnityEngine;

public sealed class GameTimerHandler : GameManager
{
	[Header("Countdown Timer")]
	private int _currentTime;

	private bool _gameIsStarted = false;
	
	protected override void AddEventListeners()
	{
		
	}

	protected override void RemoveEventListeners()
	{
		
	}

	private void Awake()
	{
		CheckPreload();
	}

	protected override void Initialize()
	{
		base.Initialize();

		StopGame(GameState.STARTING);
		
		LockCursor();

		InitializeCountdownTimer();
	}

	private void CheckPreload()
	{
		if (!SaveSystem.GetWasLoaded())
		{
			if (!SaveSystem.GetWasCreated())
			{
				SceneHandler.LoadScene(SceneEnum.PRELOAD);
			}

			Debug.LogWarning("Save System has been loaded forcibly. Start the game from the Preload scene!");
		}
	}

	private void InitializeCountdownTimer()
	{
		int timeToStartGame = SaveSystem.GetLocalGameData().TimeToStartGame;
		
		SetCurrentTime(timeToStartGame);

		if (timeToStartGame > 0)
		{
			StartCoroutine(CountdownTimer());
		}
		else
		{
			StartGame();
			
			StartMatchTimer();
		}
	}

	private void HandleGameTimer()
	{
		if (_currentTime <= 0)
		{
			if (!_gameIsStarted)
			{
				StartGame();
				
				StartMatchTimer();
			}
			else
			{
				FinishGame();
			}
		}
	}

	private IEnumerator CountdownTimer()
	{
		while (_currentTime > 0)
		{
			_localGameEvents.OnGameTimeChanged?.Invoke(_currentTime);
			
			yield return new WaitForSecondsRealtime(1f);

			_currentTime--;
		}
		
		_localGameEvents.OnGameTimeChanged?.Invoke(0);
		
		HandleGameTimer();
	}

	private void StartGame()
	{
		_gameIsStarted = true;

		ResumeGame();
			
		_globalGameEvents.OnGameIsStarted?.Invoke();
	}

	private void StartMatchTimer()
	{
		int gameDuration = SaveSystem.GetLocalGameData().GameDuration;
			
		SetCurrentTime(gameDuration);

		StartCoroutine(CountdownTimer());
	}

	private void FinishGame()
	{
		_globalGameEvents.OnGameIsFinished?.Invoke();

		StopGame(GameState.LEVEL_COMPLETED);
	}

	private void SetCurrentTime(int time)
	{
		_currentTime = time;
	}
}
