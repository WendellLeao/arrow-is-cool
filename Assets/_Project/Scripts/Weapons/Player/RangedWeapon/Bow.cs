using UnityEngine;

public sealed class Bow : RangedWeapon
{
	[SerializeField] private float _chargeSpeed;
	
	[Header("Rotation")]
	[SerializeField] private float _rotationSpeed = 4f;
	
	[Header("Bow Aim")]
	[SerializeField] private Transform _aimingSpawnPointTransform;
	
	[Header("Animations")]
	[SerializeField] private Animator _animator;
	
	[Header("Arrow")]
	private Arrow _currentArrow;

	private float _currentArrowShootForce;

	private bool _isPullingArrow, _isShootingArrow, _isAiming, _canPlayAimingSound = true;
	
	private static readonly int _isAimingID = Animator.StringToHash("isAiming");

	protected override void HandleShooting(PlayerInputsData playerInputsData)
	{
		if (CanPullArrow(playerInputsData))
		{
			PullArrow();
		}
		
		if (_isPullingArrow)
		{
			ChargeArrowShootForce();
			
			if(!playerInputsData.IsShooting)
			{
				ReleaseArrow();
			}
		}
	}

	protected override void HandleAiming(PlayerInputsData playerInputsData)
	{
		if (!_isPullingArrow)
		{
			_isAiming = playerInputsData.IsAiming;
			
			_animator.SetBool(_isAimingID, _isAiming);
		}

		HandleAimingSound();
	}

	private void FixedUpdate()
	{
		if (_isShootingArrow)
		{
			ShootArrow();
		}
	}
	
	private void Update()
	{
		RotateTowardsCameraDirection();
	}

	private void PullArrow()
	{
		SoundManager.PlaySound(Sound.PULL_ARROW, transform.position);
		
		SetCurrentArrow();

		ChargeArrowShootForce();

		SetCurrentArrowProperties();
		
		SetCurrentArrowTransform();
		
		_isPullingArrow = true;
	}

	private void ReleaseArrow()
	{
		SoundManager.PlaySound(Sound.SHOOT_ARROW, transform.position);
		
		_isShootingArrow = true;
		
		_weaponAmmo.Decrease();

		ResetCurrentArrowProperties();
		
		_nextFire = Time.time + _fireRate;

		_isPullingArrow = false;
	}

	private void ChargeArrowShootForce()
	{ 
		if (_currentArrowShootForce <= _currentArrow.GetMaxShootForce())
		{
			_currentArrowShootForce += Time.deltaTime * _chargeSpeed;
			
			_currentArrow.SetCurrentShootForce(_currentArrowShootForce);
		}
	}

	private void ShootArrow()
	{
		_currentArrow.AddVelocity(_cameraTransform.forward);
			
		_currentArrow.SetRotation(Quaternion.LookRotation(_currentArrow.GetRigidbody().velocity));

		_isShootingArrow = false;
	}
	
	private void RotateTowardsCameraDirection()
	{
		Vector3 cameraRotation = _cameraTransform.eulerAngles;
		
		Quaternion targetRotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0f);

		float newRotationSpeed = _rotationSpeed * Time.deltaTime;
		
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, newRotationSpeed);
	}

	private void HandleAimingSound()
	{
		if (_isAiming)
		{
			if (_canPlayAimingSound)
			{
				SoundManager.PlaySound(Sound.AIM_BOW, transform.position);

				_canPlayAimingSound = false;
			}
		}
		else
		{
			_canPlayAimingSound = true;
		}
	}
	
	private void ResetCurrentArrowProperties()
	{
		_currentArrow.ActiveBoxCollider();
		
		Rigidbody currentArrowRigidbody = _currentArrow.GetRigidbody();
		
		currentArrowRigidbody.useGravity = true;
			
		_currentArrow.SetCanCollide(true);
		
		_currentArrow.CanUnparent = true;
		
		_currentArrowShootForce = 0f;
	}
	
	private void SetCurrentArrowProperties()
	{
		_currentArrow.DeactiveBoxCollider();
		
		_currentArrow.SetCanCollide(false);
		
		_currentArrow.GetRigidbody().useGravity = false;

		_currentArrow.CanUnparent = false;
	}

	private void SetCurrentArrow()
	{
		GameObject projectileGameObject = ObjectPooler.GetObjectFromPool(PoolType.ARROW_PROJECTILE);
					
		_currentArrow = projectileGameObject.GetComponent<Arrow>();

		_currentArrow.SetIsBeingPulled(true);
	}
	
	private void SetCurrentArrowTransform()
	{
		_currentArrow.SetParent(transform);

		Transform currentSpawnPointTransform;
		
		if (_isAiming)
		{
			currentSpawnPointTransform = _aimingSpawnPointTransform;
		}
		else
		{
			currentSpawnPointTransform = _spawnPointTransform;
		}
		
		_currentArrow.SetRotation(currentSpawnPointTransform.rotation);
		
		_currentArrow.SetPosition(currentSpawnPointTransform.position);
	}
	
	private bool CanPullArrow(PlayerInputsData playerInputsData)
	{
		return playerInputsData.IsShooting && _weaponAmmo.GetCurrentAmmo() > 0 && Time.time > _nextFire && !_isPullingArrow;
	}
}
