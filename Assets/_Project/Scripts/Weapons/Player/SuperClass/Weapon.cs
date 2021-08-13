using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
	[Header("Game Events")]
	[SerializeField] protected GlobalGameEvents _globalGameEvents;
	[SerializeField] protected LocalGameEvents _localGameEvents;

	protected float _nextFire;

	protected WeaponAmmo _weaponAmmo;

	protected abstract void AddEventListeners();
	
	protected abstract void AddInputEventListeners();

	protected abstract void RemoveEventListeners();

	protected abstract void RemoveInputEventListeners();

	protected virtual void OnEnable()
	{
		_globalGameEvents.OnGameIsStarted += AddEventListeners;
	}

	protected virtual void OnDisable()
	{
		RemoveEventListeners();
	}

	protected virtual void Initialize()
	{
		
	}
	
	protected virtual void OnGameStateChanged_HandleInputListeners(GameState gameState)
	{
		RemoveInputEventListeners();
		
		if (gameState == GameState.PLAYING)
		{
			AddInputEventListeners();
		}
	}

	private void Start()
	{
		Initialize();
	}
}
