using UnityEngine;

public sealed class ArrowItem : Item
{
	[SerializeField] private int _ammoAmount;
	
	protected override void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out Bow bow))
		{
			SoundManager.PlaySound(Sound.ARROW_ITEM_PICKED, transform.position);
			
			bow.GetWeaponAmmo().AddAmmo(_ammoAmount);
			
			DeactivateObject();
		}
	}

	protected override void ReturnItemToPool()
	{
		ObjectPooler.ReturnObjectToPool(PoolType.ARROW_ITEM, this.gameObject);
	}
}
