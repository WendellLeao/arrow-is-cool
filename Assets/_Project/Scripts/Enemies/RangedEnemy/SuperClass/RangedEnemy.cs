using System.Collections;
using UnityEngine;

public abstract class RangedEnemy : Enemy
{
	[Header("Arrow Shooting")]
	[SerializeField] protected Transform _arrowSpawnPoint;

	[SerializeField] protected float _distanceToShoot = 15f;

	protected abstract void PlayShootingSound();

	protected abstract Projectile GetProjectile();
	
	protected override void Update()
	{
		base.Update();
		
		FacePlayer();
	}

	protected override void Initialize()
	{
		base.Initialize();

		_canAttack = true;
	}

	protected override void HandleEnemyStates()
	{
		if (GetPlayerDistance() <= _distanceToShoot)
		{
			if (_canAttack)
			{
				_enemyState = EnemyState.ATTACKING;
			}
			else
			{
				_enemyState = EnemyState.IDLE;
			}
		}
		else
		{
			_enemyState = EnemyState.IDLE;
		
			_canAttack = true;
		}
	}

	protected override void ChasePlayer()
	{
		
	}

	protected override void AttackPlayer()
	{
		
	}

	protected override void StayIdle()
	{
		
	}
	
	//Animation event listener
	protected void ShootProjectile()
	{
		if (_canAttack)
		{ 
			_canAttack = false;
			
			PlayShootingSound();

			Projectile projectile = GetProjectile();
			
			projectile.SetDamageAmount(_enemyData.AttackForce);
				
			projectile.SetPosition(_arrowSpawnPoint.position);
					
			projectile.AddVelocity(_arrowSpawnPoint.forward);
					
			projectile.SetRotation(Quaternion.LookRotation(projectile.GetRigidbody().velocity));
			
			StartCoroutine(AttackCooldown());
		}
	}

	protected IEnumerator AttackCooldown()
	{
		float animationDuration = _animator.GetCurrentAnimatorClipInfo(0).Length;
		
		yield return new WaitForSeconds(animationDuration + _enemyData.AttackRate);
		
		_canAttack = true;
	}
}
