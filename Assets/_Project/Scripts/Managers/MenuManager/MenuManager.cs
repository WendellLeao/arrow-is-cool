using UnityEngine.UI;
using UnityEngine;

public sealed class MenuManager : GameManager
{
	[Header("Menus Rect Transform")]
	[SerializeField] private RectTransform _mainMenuRectTransform;
	[SerializeField] private RectTransform _settingsMenuRectTransform;
	[SerializeField] private RectTransform _loadingScreenRectTransform;
	[SerializeField] private RectTransform _gameSettingsMenuRectTransform;
	[SerializeField] private RectTransform _videoSettingsMenuRectTransform;
	[SerializeField] private RectTransform _audioSettingsMenuRectTransform;
    
	[Header("Main Menu Buttons")]
	[SerializeField] private Button _newGameButton;
	[SerializeField] private Button _showSettingsMenuButton;
	[SerializeField] private Button _quitGameButton;

	[Header("Settings Menu Buttons")]
	[SerializeField] private Button _showGameSettingsButton;
	[SerializeField] private Button _showVideoSettingsButton; 
	[SerializeField] private Button _showAudioSettingsButton; 
	[SerializeField] private Button _settingsBackMenuButton;
	[SerializeField] private Button _gameBackMenuButton;
	[SerializeField] private Button _videoBackMenuButton;
	[SerializeField] private Button _audioBackMenuButton;

	[Header("Async Scene Handler")]
	[SerializeField] private AsyncSceneHandler _asyncSceneHandler;

	private bool _canPlayButtonClickSound = false;
	
	protected override void AddEventListeners()
	{
		_newGameButton.onClick.AddListener(OnClick_StartNewGame);

		_showSettingsMenuButton.onClick.AddListener(delegate { ShowMenu(Menu.SETTINGS); });

		_settingsBackMenuButton.onClick.AddListener(delegate { ShowMenu(Menu.MAIN); });

		_showGameSettingsButton.onClick.AddListener(delegate { ShowMenu(Menu.GAME_SETTINGS); });
		_showVideoSettingsButton.onClick.AddListener(delegate { ShowMenu(Menu.VIDEO_SETTINGS); });
		_showAudioSettingsButton.onClick.AddListener(delegate { ShowMenu(Menu.AUDIO_SETTINGS); });

		_gameBackMenuButton.onClick.AddListener(delegate { ShowMenu(Menu.SETTINGS); });
		_videoBackMenuButton.onClick.AddListener(delegate { ShowMenu(Menu.SETTINGS); });
		_audioBackMenuButton.onClick.AddListener(delegate { ShowMenu(Menu.SETTINGS); });

		_quitGameButton.onClick.AddListener(OnClick_QuitGame);
	}

	protected override void RemoveEventListeners()
	{
		_newGameButton.onClick.RemoveAllListeners();

		_showSettingsMenuButton.onClick.RemoveAllListeners();

		_settingsBackMenuButton.onClick.RemoveAllListeners();

		_showGameSettingsButton.onClick.RemoveAllListeners();
		_showVideoSettingsButton.onClick.RemoveAllListeners();
		_showAudioSettingsButton.onClick.RemoveAllListeners();

		_gameBackMenuButton.onClick.RemoveAllListeners();
		_videoBackMenuButton.onClick.RemoveAllListeners();
		_audioBackMenuButton.onClick.RemoveAllListeners();

		_quitGameButton.onClick.RemoveAllListeners();
	}
	
	protected override void Initialize()
	{
		base.Initialize();

		ResumeGame();

		SetMenusObjectPosition();

		ShowMenu(Menu.MAIN);

		PlayGameTheme();
	}

	protected override void ResumeGame()
	{
		Time.timeScale = 1f;
	}
	
	private void Awake()
	{
		CheckPreload();
	}
	
	private void CheckPreload()
	{
		if (!SaveSystem.GetWasLoaded() && !SaveSystem.GetWasCreated())
		{
			//Force Save System Loading
			SceneHandler.LoadScene(SceneEnum.PRELOAD);
		}
	}

	private void ShowMenu(Menu menu)
	{
		DeactiveMenus();

		switch (menu)
		{
			case Menu.MAIN:
			{
				_mainMenuRectTransform.gameObject.SetActive(true);
				break;
			}
			case Menu.SETTINGS:
			{
				_settingsMenuRectTransform.gameObject.SetActive(true);
				break;
			}
			case Menu.GAME_SETTINGS:
			{
				_gameSettingsMenuRectTransform.gameObject.SetActive(true);
				break;
			}
			case Menu.VIDEO_SETTINGS:
			{
				_videoSettingsMenuRectTransform.gameObject.SetActive(true);
				break;
			}
			case Menu.AUDIO_SETTINGS:
			{
				_audioSettingsMenuRectTransform.gameObject.SetActive(true);
				break;
			}
			case Menu.LOADING_SCREEN:
			{
				_loadingScreenRectTransform.gameObject.SetActive(true);
				break;
			}
		}
		
		HandleButtonClickSound(menu);
	}

	private void PlayGameTheme()
	{
		SoundManager.PlaySound(Sound.GAME_THEME);
	}

	private void HandleButtonClickSound(Menu menu)
	{
		if (menu != Menu.MAIN)
		{
			_canPlayButtonClickSound = true;
		}

		if (_canPlayButtonClickSound)
		{
			PlayButtonClickSound();
		}
	}
	
	private void PlayButtonClickSound()
	{
		SoundManager.PlaySound(Sound.UI_BUTTON_CLICK);
	}

	private void DeactiveMenus()
	{
		_mainMenuRectTransform.gameObject.SetActive(false);
		_settingsMenuRectTransform.gameObject.SetActive(false);
		_loadingScreenRectTransform.gameObject.SetActive(false);
		_gameSettingsMenuRectTransform.gameObject.SetActive(false);
		_videoSettingsMenuRectTransform.gameObject.SetActive(false);
		_audioSettingsMenuRectTransform.gameObject.SetActive(false);
	}
	
	private void OnClick_StartNewGame()
	{
		ShowMenu(Menu.LOADING_SCREEN);

		_asyncSceneHandler.LoadSingleSceneAsync(SceneEnum.LEVEL_01);
		
		PlayButtonClickSound();
	}

	private void OnClick_QuitGame()
	{
		PlayButtonClickSound();
		
		Application.Quit();
	}

	private void SetMenusObjectPosition()
	{
		_mainMenuRectTransform.anchoredPosition = Vector2.zero;
		_settingsMenuRectTransform.anchoredPosition = Vector2.zero;
		_loadingScreenRectTransform.anchoredPosition = Vector2.zero;
		_gameSettingsMenuRectTransform.anchoredPosition = Vector2.zero;
		_videoSettingsMenuRectTransform.anchoredPosition = Vector2.zero;
		_audioSettingsMenuRectTransform.anchoredPosition = Vector2.zero;
	}
}
