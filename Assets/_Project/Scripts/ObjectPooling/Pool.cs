using UnityEngine;

[System.Serializable]
public sealed class Pool
{
	public PoolType PoolType;
	
	public GameObject ObjectToPool;
	
	public int StartAmount;
}
