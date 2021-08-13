using UnityEngine;
using TMPro;

public sealed class ScoreUI : GameUI
{
	[Header("UI Text")]
	[SerializeField] private TMP_Text _scoreText; 

	[Header("Score")]
	private int _totalScore;

	protected override void SubscribeEvents()
	{
		base.SubscribeEvents();

		_globalGameEvents.OnGameIsFinished += OnGameIsFinished_RaiseTotalScore;
		
		_localGameEvents.OnScoreChanged += OnScoreChanged_UpdateScoreUI;
	}

	protected override void UnsubscribeEvents()
	{
		base.UnsubscribeEvents();
		
		_globalGameEvents.OnGameIsFinished -= OnGameIsFinished_RaiseTotalScore;
		
		_localGameEvents.OnScoreChanged -= OnScoreChanged_UpdateScoreUI;
	}

	protected override void Initialize()
	{
		base.Initialize();
		
		_localGameEvents.OnScoreChanged?.Invoke(0);
	}

	private void OnScoreChanged_UpdateScoreUI(int score)
	{
		_totalScore += score;

		_scoreText.text = $"SCORE : {_totalScore}";
	}

	private void OnGameIsFinished_RaiseTotalScore()
	{
		if (_totalScore > SaveSystem.GetLocalGameData().Highscore)
		{
			SaveSystem.GetLocalGameData().Highscore = _totalScore;

			SaveSystem.SaveGameData();
		}
		
		_localGameEvents.OnScoreChanged?.Invoke(_totalScore);
	}
}
