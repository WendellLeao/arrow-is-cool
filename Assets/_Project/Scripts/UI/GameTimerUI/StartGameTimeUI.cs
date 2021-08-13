using UnityEngine;
using TMPro;

public sealed class StartGameTimeUI : GameUI
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
		_childGameObject.SetActive(gameState == GameState.STARTING);
	}

	private void OnGameTimeChanged_UpdateTimeTextUI(int time)
	{
		if (time > 0)
		{
			_timeText.text = time.ToString();
		}
	}
}
