using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
	[Header("Enemy Data")]
	[SerializeField] protected EnemyData _enemyData;

	[Header("Game Events")]
	[SerializeField] protected LocalGameEvents _localGameEvents;
	
	[Header("Enemy Components")]
	[SerializeField] protected Animator _animator;
	
	[SerializeField] protected BoxCollider _boxCollider;
	[SerializeField] protected BoxCollider _bodyBoxCollider;
	
	[Header("Materials")]
	[SerializeField] protected SkinnedMeshRenderer _skinnedMeshRenderer;
	
	[Header("Animator Parameters IDs")]
	protected static readonly int _isBeingDamagedID = Animator.StringToHash("isBeingDamaged");
	protected static readonly int _isAttackingID = Animator.StringToHash("isAttacking");
	protected static readonly int _isMovingID = Animator.StringToHash("isMoving");
	protected static readonly int _isIdleID = Animator.StringToHash("isIdle");
	protected static readonly int _isDeadID = Animator.StringToHash("isDead");
	
	protected HealthSystem _healthSystem;
	
	protected Vector3 _playerPosition;
	
	protected EnemyState _enemyState;

	protected bool _canAttack, _isBeingHitted, _canAddScore = true;

	protected int _randomMaterialIndex;
	
	private ItemDropper _itemDropper = new ItemDropper();

	protected abstract void HandleEnemyStates();
	
	protected abstract void ChasePlayer();
	
	protected abstract void AttackPlayer();
	
	protected abstract void StayIdle();
	
	protected abstract void PlayHittedSound();

	protected abstract void ReturnEnemyToPool();
	
	public virtual void TakeDamage(int damageAmount)
	{
		_healthSystem.Damage(damageAmount);

		if (!_isBeingHitted)
		{
			_animator.SetTrigger(_isBeingDamagedID);
		}

		if (_healthSystem.GetCurrentHealthAmount() <= 0)
		{
			_enemyState = EnemyState.DEAD;
			
			SoundManager.PlaySound(Sound.MONSTER_GRUNT);
		}
		else
		{
			PlayHittedSound();
		}
		
		StartCoroutine(BeingHittedCooldown());
	}

	protected virtual void OnEnable()
	{
		SetRandomMaterial();

		_boxCollider.enabled = true;

		_bodyBoxCollider.enabled = true;
	}
	
	protected virtual void OnDisable()
	{
		ResetHealth();

		ResetEnemyState();

		ReturnEnemyToPool();

		_canAddScore = true;
	}
	
	protected virtual void Update()
	{
		if (_enemyState != EnemyState.DEAD)
		{
			HandleEnemyStates();
		}

		switch (_enemyState)
		{
			case EnemyState.IDLE:
			{
				StayIdle();
				break;
			}
			case EnemyState.CHASING:
			{
				ChasePlayer();
				break;
			}
			case EnemyState.ATTACKING:
			{
				AttackPlayer();
				break;
			}
			case EnemyState.DEAD:
			{
				Die();
				break;
			}
		}
		
		HandleAnimations();
	}
	
	protected virtual void Initialize()
	{
		
	}

	protected virtual void Die()
	{
		_boxCollider.enabled = false;

		_bodyBoxCollider.enabled = false;

		if (_canAddScore)
		{
			_localGameEvents.OnScoreChanged?.Invoke(_enemyData.ScoreAmountOnDeath);

			_canAddScore = false;
		}
	}

	protected virtual void FacePlayer()
	{
		Vector3 direction = (_playerPosition - transform.position).normalized;
		
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _enemyData.RotationSpeed * Time.deltaTime);
	}

	protected virtual void HandleAnimations()
	{
		if (_enemyState != EnemyState.DEAD)
		{
			_animator.SetBool(_isMovingID, _enemyState == EnemyState.CHASING);
			
			_animator.SetBool(_isAttackingID, _enemyState == EnemyState.ATTACKING);
			
			_animator.SetBool(_isIdleID, _enemyState == EnemyState.IDLE);
		}
		else
		{
			_animator.SetBool(_isDeadID, true);
		}
	}
	
	protected IEnumerator BeingHittedCooldown()
	{
		_isBeingHitted = true;
		
		float damagedTime = 0.25f;
		
		yield return new WaitForSeconds(damagedTime);
		
		_isBeingHitted = false;
	}

	private void Awake()
	{
		InitializeHealthSystem();
	}

	private void Start()
	{
		Initialize();
	}

	private void InitializeHealthSystem()
	{
		_healthSystem = new HealthSystem(_enemyData.MaxHealthAmount);
	}
	
	//Called in the animator
	protected void DeactivateEnemy()
	{
		DropRandomItem();
		
		gameObject.SetActive(false);
	}

	private void DropRandomItem()
	{
		Vector3 enemyTransform = transform.position;
		
		_itemDropper.DropRandomItem();
		
		_itemDropper.SetDroppedItemPosition(enemyTransform);
	}

	private void ResetHealth()
	{
		_healthSystem.ResetCurrentHealthAmount();
	}

	private void ResetEnemyState()
	{
		_enemyState = EnemyState.IDLE;
		
		_animator.SetBool(_isIdleID, true);
	}

	public float GetPlayerDistance()
	{
		return Vector3.Distance(_playerPosition, transform.position);
	}

	public EnemyState GetEnemyState()
	{
		return _enemyState;
	}

	public void SetRandomMaterial()
	{
		_randomMaterialIndex = Random.Range(0, _enemyData.Materials.Length);
		
		_skinnedMeshRenderer.material = _enemyData.Materials[_randomMaterialIndex];
	}
	
	public void SetPosition(Vector3 newPosition)
	{
		transform.position = newPosition;
	}
	
	public void SetPlayerPosition(Vector3 playerPosition)
	{
		_playerPosition = playerPosition;
	}
}
