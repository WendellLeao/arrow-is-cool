using UnityEngine.UI;
using UnityEngine;

public abstract class SettingsHandler : MonoBehaviour
{
	[Header("Buttons")]
	[SerializeField] protected Button _resetToDefaultButton;

	[Header("Save System")]
	protected LocalGameData _localGameData;
	
	protected abstract void AddEventListeners();

	protected abstract void RemoveEventListeners();
	
	protected abstract void ResetToDefault();
	
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
		_localGameData = SaveSystem.GetLocalGameData();

		HandleSettingsReset();
	}

	private void Start()
	{
		Initialize();
	}

	private void HandleSettingsReset()
	{
		if (SaveSystem.GetWasCreated())
		{
			ResetToDefault();
		}
	}
}
