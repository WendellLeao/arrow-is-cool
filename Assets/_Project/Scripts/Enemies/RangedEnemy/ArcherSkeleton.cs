using UnityEngine;

public sealed class ArcherSkeleton : RangedEnemy
{
	protected override void PlayHittedSound()
	{
		SoundManager.PlaySound(Sound.ARCHER_SKELETON_HITTED, transform.position);
	}

	protected override void PlayShootingSound()
	{
		SoundManager.PlaySound(Sound.SHOOT_ARROW, transform.position);
	}

	protected override void ReturnEnemyToPool()
	{
		ObjectPooler.ReturnObjectToPool(PoolType.ARCHER_SKELETON, this.gameObject);
	}

	protected override Projectile GetProjectile()
	{
		GameObject projectileObject = ObjectPooler.GetObjectFromPool(PoolType.ARROW_PROJECTILE);

		return projectileObject.GetComponent<Projectile>();
	}
}
