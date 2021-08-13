using UnityEngine;

[CreateAssetMenu (menuName = "Weapons/Enemy Weapon Data")]
public sealed class EnemyWeaponData : ScriptableObject
{
	[Header("Object Pooling")]
	public PoolType WeaponPool;
	
	[Header("Materials")]
	public Material[] Materials;
}
