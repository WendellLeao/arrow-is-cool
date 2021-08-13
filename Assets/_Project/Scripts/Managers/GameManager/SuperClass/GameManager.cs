using UnityEngine;

public abstract class GameManager : MonoBehaviour
{
	[Header("Game Events")]
	[SerializeField] protected GlobalGameEvents _globalGameEvents;
	
	[SerializeField] protected LocalGameEvents _localGameEvents;
	
	protected abstract void AddEventListeners();

	protected abstract void RemoveEventListeners();
	
	protected virtual void OnEnable()
	{
		AddEventListeners();
	}
	
	protected virtual void OnDisable()
	{
		RemoveEventListeners();
	}
	
	protected virtual void Initialize()
	{
		
	}

	protected virtual void StopGame(GameState gameState)
	{
		Time.timeScale = 0f;

		UnlockCursor();
		
		ChangeGameState(gameState);
	}
	
      protected virtual void ResumeGame()
	{
		Time.timeScale = 1f;

		LockCursor();

		ChangeGameState(GameState.PLAYING);
	}

	protected void ChangeGameState(GameState newGameState)
	{
		_globalGameEvents.OnGameStateChanged?.Invoke(newGameState);
	}

	protected void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	protected void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	
	private void Start()
	{
		Initialize();
	}
}
