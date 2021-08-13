using UnityEngine;

public sealed class PlayerHealthController : Player, IDamageable
{
	[Header("Health System")]
	[SerializeField] private int _maxHealthAmount = 100;
	
	[Header("Health System")]
	private HealthSystem _healthSystem;

	public void TakeDamage(int damageAmount)
	{
		SoundManager.PlaySound(Sound.PLAYER_HITTED, transform.position);
		
		_healthSystem.Damage(damageAmount);

		RaiseOnHealthChangedEvent();

		_localGameEvents.OnPlayerIsDamaged?.Invoke();

		CheckIfPlayerDied();
	}

	public void AddHealth(int healthAmount)
	{
		_healthSystem.AddHealth(healthAmount);
		
		RaiseOnHealthChangedEvent();
	}
	
	protected override void Initialize()
	{
		base.Initialize();

		_healthSystem = new HealthSystem(_maxHealthAmount);
	}

	private void RaiseOnHealthChangedEvent()
	{
		int currentHealthAmount = _healthSystem.GetCurrentHealthAmount();
		int maxHealthAmount = _healthSystem.GetMaxHealthAmount();
		
		_localGameEvents.OnHealthChanged?.Invoke(currentHealthAmount, maxHealthAmount);
	}
	
	private void CheckIfPlayerDied()
	{
		if(_healthSystem.GetCurrentHealthAmount() <= 0)
		{
			_globalGameEvents.OnPlayerDied?.Invoke();
		}
	}
}
