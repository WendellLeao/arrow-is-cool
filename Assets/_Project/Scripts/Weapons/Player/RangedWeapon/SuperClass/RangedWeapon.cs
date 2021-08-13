using UnityEngine;

public abstract class RangedWeapon : Weapon
{
	[Header("Spawn Projectile")]
	[SerializeField] protected Transform _spawnPointTransform;
	[SerializeField] protected Transform _cameraTransform;

	[Header("Ammo")]
	[SerializeField] protected int _startAmmoAmount;

	[Header("Shooting")]
	[SerializeField] protected float _fireRate;

	protected abstract void HandleShooting(PlayerInputsData playerInputsData);

	protected abstract void HandleAiming(PlayerInputsData playerInputsData);

	protected override void AddEventListeners()
	{
		_globalGameEvents.OnGameStateChanged += OnGameStateChanged_HandleInputListeners;

		AddInputEventListeners();
	}

	protected override void AddInputEventListeners()
	{
		_localGameEvents.OnReadPlayerInputs += HandleShooting;
		_localGameEvents.OnReadPlayerInputs += HandleAiming;
	}

	protected override void RemoveEventListeners()
	{
		_globalGameEvents.OnGameIsStarted -= AddEventListeners;

		_globalGameEvents.OnGameStateChanged -= OnGameStateChanged_HandleInputListeners;

		RemoveInputEventListeners();
	}

	protected override void RemoveInputEventListeners()
	{
		_localGameEvents.OnReadPlayerInputs -= HandleShooting;
		_localGameEvents.OnReadPlayerInputs -= HandleAiming;
	}

	protected override void Initialize()
	{
		base.Initialize();
		
		InitializeAmmo();
	}

	private void InitializeAmmo()
	{
		_weaponAmmo = new WeaponAmmo(_startAmmoAmount, _localGameEvents);
	}
	
	public WeaponAmmo GetWeaponAmmo()
	{
		return _weaponAmmo;
	}
}
