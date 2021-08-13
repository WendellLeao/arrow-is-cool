using UnityEngine;

public sealed class SoundManagerInitializer : MonoBehaviour
{
	[SerializeField] private AudioSourceProperties[] _audioSourceProperties;

	private void Awake()
	{
		InitializeSoundManager();
	}

	private void InitializeSoundManager()
	{
		SoundManager.Initialize(_audioSourceProperties);
	}
}
