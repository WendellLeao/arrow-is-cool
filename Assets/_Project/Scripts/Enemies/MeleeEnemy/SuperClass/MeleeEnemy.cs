using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public abstract class MeleeEnemy : Enemy
{
	[Header("I.A")]
	[SerializeField] protected NavMeshAgent _navMeshAgent;
	
	[Header("Weapon")]
	[SerializeField] protected EnemyWeaponData[] _weapons;
	
	[SerializeField] protected LayerMask _playerLayer;
	
	[SerializeField] protected Transform _attackPoint;
	
	[SerializeField] protected float _attackRange = 1.2f;

	protected bool _isAttacking, _swordIsActivated;

	//Animation event listener
	protected abstract void PlayWeaponAttackSound();
	
	protected override void Update()
	{
		base.Update();
		
		HandleSword();
		
		if (_enemyState != EnemyState.DEAD && !_isAttacking && !_isBeingHitted)
		{
			FacePlayer();
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		
		ResetAttack();

		_enemyState = EnemyState.CHASING;
	}

	protected override void HandleEnemyStates()
	{
		if (GetPlayerDistance() <= _navMeshAgent.stoppingDistance)
		{
			if (!_isBeingHitted)
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
		}
		else
		{
			if (!_isAttacking && !_isBeingHitted)
			{
				_enemyState = EnemyState.CHASING;
			
				ResetAttack();
			}
			else
			{
				_enemyState = EnemyState.IDLE;
			}
		}
	}
	
	protected override void ChasePlayer()
	{
		_navMeshAgent.SetDestination(_playerPosition);
	}

	protected override void AttackPlayer()
	{
		_navMeshAgent.SetDestination(transform.position);
		
		_isAttacking = true;

		StartCoroutine(AttackCooldown());
	}

	protected override void StayIdle()
	{
		_navMeshAgent.SetDestination(transform.position);
	}

	protected override void Die()
	{
		base.Die();

		_navMeshAgent.SetDestination(transform.position);
	}

	protected void HandleSword()
	{
		if (_swordIsActivated)
		{
			Collider[] colliders = Physics.OverlapSphere(_attackPoint.position, _attackRange, _playerLayer);

			foreach (Collider objectCollider in colliders)
			{
				if (objectCollider.TryGetComponent(out PlayerHealthController playerHealthController))
				{
					playerHealthController.TakeDamage(_enemyData.AttackForce);

					_swordIsActivated = false;
				}
			}
		}
	}
	
	protected IEnumerator AttackCooldown()
	{
		float animationDuration = _animator.GetCurrentAnimatorClipInfo(0).Length;

		yield return new WaitForSeconds(animationDuration);
		
		_canAttack = false;

		_isAttacking = false;

		yield return new WaitForSeconds(_enemyData.AttackRate);
		
		_canAttack = true;
	}

	//Animation event listener
	protected void ActiveSword()
	{
		_swordIsActivated = true;
	}
	
	protected void ResetAttack()
	{
		_swordIsActivated = false;

		_canAttack = true;
	} 
		
	private void OnDrawGizmosSelected()
	{
		if (_attackPoint == null)
		{
			return;
		}

		Gizmos.color = Color.red;
		
		Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
	}
}
