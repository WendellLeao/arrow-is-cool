using UnityEngine;

public sealed class HealthItem : Item
{
	[SerializeField] private int _healthAmount;

	protected override void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out PlayerHealthController playerHealthController))
		{
			SoundManager.PlaySound(Sound.HEALTH_ITEM_PICKED, transform.position);
			
			playerHealthController.AddHealth(_healthAmount);
		
			DeactivateObject();
		}
	}

	protected override void ReturnItemToPool()
	{
		ObjectPooler.ReturnObjectToPool(PoolType.HEALTH_ITEM, this.gameObject);
	}
}
