using UnityEngine.UI;
using UnityEngine;

public sealed class LoseGamePanelUI : PanelUI
{
	[Header("Buttons")]
	[SerializeField] private Button _restartGameButton;
	[SerializeField] private Button _mainMenuButton;
	
	protected override void SubscribeEvents()
	{
		_globalGameEvents.OnPlayerDied += ShowPanel;

		_restartGameButton.onClick.AddListener(delegate
		{
			SceneHandler.ReloadScene();

			PlayButtonClickSound();
		});
		
		_mainMenuButton.onClick.AddListener(delegate
		{
			SceneHandler.BackToMainMenu();

			PlayButtonClickSound();
		});
	}

	protected override void UnsubscribeEvents()
	{
		_globalGameEvents.OnPlayerDied -= ShowPanel;
		
		_restartGameButton.onClick.RemoveAllListeners();
		_mainMenuButton.onClick.RemoveAllListeners();
	}
	
	private void PlayButtonClickSound()
	{
		SoundManager.PlaySound(Sound.UI_BUTTON_CLICK);
	}
}
