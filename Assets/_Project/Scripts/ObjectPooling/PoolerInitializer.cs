using UnityEngine;

public sealed class PoolerInitializer : MonoBehaviour
{
	[SerializeField] private Pool[] _pools;

	private void Start()
	{
		InitializeObjectPooler();
	}

	private void InitializeObjectPooler()
	{
		ObjectPooler.Initialize(_pools);
	}
}
