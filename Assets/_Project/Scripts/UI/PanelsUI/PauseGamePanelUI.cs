using UnityEngine.UI;
using UnityEngine;

public sealed class PauseGamePanelUI : PanelUI
{
	[Header("Buttons")]
	[SerializeField] private Button _resumeGameButton;
	[SerializeField] private Button _restartGameButton;
	[SerializeField] private Button _mainMenuButton;

	protected override void SubscribeEvents()
	{
		_globalGameEvents.OnGameIsPaused += OnGameIsPaused_HandlePauseGamePanelUI;
		
		_resumeGameButton.onClick.AddListener(ResumeGame);
		
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
		_globalGameEvents.OnGameIsPaused -= OnGameIsPaused_HandlePauseGamePanelUI;
		
		_resumeGameButton.onClick.RemoveAllListeners();
		_restartGameButton.onClick.RemoveAllListeners();
            _mainMenuButton.onClick.RemoveAllListeners();
	}

	protected override void ShowPanel()
	{
		base.ShowPanel();
		
		PlayButtonClickSound();
	}

	protected override void HidePanel()
	{
		base.HidePanel();
		
		PlayButtonClickSound();
	}

	private void OnGameIsPaused_HandlePauseGamePanelUI(bool canPauseGame)
	{
		if (canPauseGame)
		{
			ShowPanel();
		}
		else
		{
			HidePanel();
		}
	}
	
	private void ResumeGame()
	{
		_globalGameEvents.OnGameIsPaused?.Invoke(false);
	}

	private void PlayButtonClickSound()
	{
		SoundManager.PlaySound(Sound.UI_BUTTON_CLICK);
	}
}
