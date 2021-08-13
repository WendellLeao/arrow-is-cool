using UnityEngine;

public abstract class GameUI : MonoBehaviour
{
	[Header("Game Events")]
	[SerializeField] protected GlobalGameEvents _globalGameEvents;
	
	[SerializeField] protected LocalGameEvents _localGameEvents;

	[Header("Child Object")]
	[SerializeField] protected GameObject _childGameObject;

	protected virtual void OnEnable()
	{
		SubscribeEvents();
	}
	
	protected virtual void OnDisable()
	{
		UnsubscribeEvents();
	}
	
	protected virtual void SubscribeEvents()
	{
		_globalGameEvents.OnGameStateChanged += OnGameStateChanged_HandleObjectVisibility;
	}

	protected virtual void UnsubscribeEvents()
	{
		_globalGameEvents.OnGameStateChanged -= OnGameStateChanged_HandleObjectVisibility;
	}
	
	protected virtual void OnGameStateChanged_HandleObjectVisibility(GameState gameState)
	{
		_childGameObject.SetActive(gameState == GameState.PLAYING);
	}

	protected virtual void Initialize()
	{
		
	}

	private void Start()
	{
		Initialize();
	}
}
