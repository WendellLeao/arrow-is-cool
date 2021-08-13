using UnityEngine;

public abstract class Player : MonoBehaviour
{
	[Header("Game Events")]
	[SerializeField] protected GlobalGameEvents _globalGameEvents;
	
	[SerializeField] protected LocalGameEvents _localGameEvents;

	protected virtual void AddEventListeners()
	{
		_globalGameEvents.OnGameIsFinished += RemoveEventListeners;
	}

	protected virtual void RemoveEventListeners()
	{
		_globalGameEvents.OnGameIsFinished -= RemoveEventListeners;
	}
	
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

	private void Awake()
	{
		Initialize();
	}
}
