using UnityEngine;

public abstract class Particle : MonoBehaviour
{
	[Header("Particle Components")]
	[SerializeField] private ParticleSystem _particleSystem;
	
	protected abstract void ReturnToPool();

	private void OnDisable()
	{
		ReturnToPool();
	}

	private void Update()
	{
		CheckIfIsPlaying();
	}

	private void CheckIfIsPlaying()
	{
		if (!_particleSystem.isPlaying)
		{
			this.gameObject.SetActive(false);
		}
	}
}
