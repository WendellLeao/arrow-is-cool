using UnityEngine.UI;
using UnityEngine;
using TMPro;

public sealed class LevelCompletedPanelUI : PanelUI
{
	[Header("Text UI")]
	[SerializeField] private TMP_Text _totalScoreText;
	[SerializeField] private TMP_Text _enemiesDefeatedAmountText;
	
	[Header("Buttons")]
	[SerializeField] private Button _mainMenuButton;
	
	protected override void SubscribeEvents()
	{
		_globalGameEvents.OnGameIsFinished += ShowPanel;
		
		_localGameEvents.OnScoreChanged += OnScoreChanged_SetTotalScoreTextUI;

		_globalGameEvents.OnRaseEnemiesDefeated += OnEnemyDied_SetTotalEnemiesDefeatedTextUI;
		
		_mainMenuButton.onClick.AddListener(delegate
		{
			SceneHandler.BackToMainMenu();
			
			SoundManager.PlaySound(Sound.UI_BUTTON_CLICK);
		});
	}

	protected override void UnsubscribeEvents()
	{
		_globalGameEvents.OnGameIsFinished -= ShowPanel;
			
		_localGameEvents.OnScoreChanged += OnScoreChanged_SetTotalScoreTextUI;
		
		_globalGameEvents.OnRaseEnemiesDefeated -= OnEnemyDied_SetTotalEnemiesDefeatedTextUI;
		
		_mainMenuButton.onClick.RemoveAllListeners();
	}
	
	private void OnScoreChanged_SetTotalScoreTextUI(int score)
	{
		_totalScoreText.text = $"Total Score: {score}";
	}

	private void OnEnemyDied_SetTotalEnemiesDefeatedTextUI(int defeatedEnemyAmount)
	{
		_enemiesDefeatedAmountText.text = $"Enemies Defeated: {defeatedEnemyAmount}";
	}
}
