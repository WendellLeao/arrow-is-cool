using UnityEngine;
using System;
using TMPro;

public sealed class MatchTimeUI : GameUI
{
	[Header("UI")]
	[SerializeField] private TMP_Text _timeText;

	protected override void SubscribeEvents()
	{
		base.SubscribeEvents();

		_localGameEvents.OnGameTimeChanged += OnGameTimeChanged_UpdateTimeTextUI;
	}

	protected override void UnsubscribeEvents()
	{
		base.UnsubscribeEvents();
		
		_localGameEvents.OnGameTimeChanged -= OnGameTimeChanged_UpdateTimeTextUI;
	}

	protected override void OnGameStateChanged_HandleObjectVisibility(GameState gameState)
	{
		_childGameObject.SetActive(gameState == GameState.PLAYING);
	}

	private void OnGameTimeChanged_UpdateTimeTextUI(int time)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(time);

		string timeSpanString = "Time: " + timeSpan.ToString("mm':'ss");
		
		_timeText.text = timeSpanString;
	}
}
