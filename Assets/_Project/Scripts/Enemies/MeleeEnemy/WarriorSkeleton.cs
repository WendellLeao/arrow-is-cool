using Random = UnityEngine.Random;
using UnityEngine;

public sealed class WarriorSkeleton : MeleeEnemy
{
	[SerializeField] private Transform _weaponSpawnPoint;

	private EnemyWeaponData _currentWeapon;

	private GameObject _currentWeaponObject;
	
	protected override void Initialize()
	{
		base.Initialize();

		SetCurrentWeapon();

		SetCurrentWeaponMaterial();
		
		SetCurrentWeaponTransform();
	}

	protected override void PlayHittedSound()
	{
		SoundManager.PlaySound(Sound.WARRIOR_SKELETON_HITTED, transform.position);
	}
	
	protected override void PlayWeaponAttackSound()
	{ 
		SoundManager.PlaySound(Sound.SWORD_SLASH, transform.position);
	}
	
	protected override void ReturnEnemyToPool()
	{
		ObjectPooler.ReturnObjectToPool(PoolType.WARRIOR_SKELETON, this.gameObject);
	}

	private void SetCurrentWeapon()
	{
		int randomSwordIndex = Random.Range(0, _weapons.Length);

		_currentWeapon = _weapons[randomSwordIndex];

		_currentWeaponObject = ObjectPooler.GetObjectFromPool(_currentWeapon.WeaponPool);
	}

	private void SetCurrentWeaponTransform()
	{
		_currentWeaponObject.transform.position = _weaponSpawnPoint.position;

		_currentWeaponObject.transform.parent = _weaponSpawnPoint;
	}

	private void SetCurrentWeaponMaterial()
	{
		MeshRenderer meshRenderer = _currentWeaponObject.GetComponent<MeshRenderer>();

		if (_currentWeapon.Materials.Length > 1)
		{
			meshRenderer.material = _currentWeapon.Materials[_randomMaterialIndex];
		}
	}
}
