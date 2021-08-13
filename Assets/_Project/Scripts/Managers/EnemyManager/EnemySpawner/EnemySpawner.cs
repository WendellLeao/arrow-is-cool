using Random = UnityEngine.Random;
using UnityEngine;

public sealed class EnemySpawner : MonoBehaviour
{
	[Header("Enemies")]
	[SerializeField] private EnemyData[] _meleeEnemies;
	[SerializeField] private EnemyData[] _rangedEnemies;
	
	[Header("Spawn Points")]
	[SerializeField] private Transform[] _meleeEnemySpawnPoints;
	[SerializeField] private Transform[] _rangedEnemySpawnPoints;

	private int _rangedSpawnPointIndex;

	public Enemy SpawnMeleeEnemy()
	{
		int spawnPointIndex = Random.Range(0, _meleeEnemySpawnPoints.Length);

		Enemy spawnedMeleeEnemy = GetMeleeEnemy();
			
		spawnedMeleeEnemy.SetPosition(_meleeEnemySpawnPoints[spawnPointIndex].position);

		return spawnedMeleeEnemy;
	}

	public Enemy SpawnRangedEnemy()
	{
		Enemy spawnedRangedEnemy = GetRangedEnemy();
		
		spawnedRangedEnemy.SetPosition(_rangedEnemySpawnPoints[_rangedSpawnPointIndex].position);
		
		return spawnedRangedEnemy;
	}
	
	private Enemy GetMeleeEnemy()
	{
		int randomMeleeEnemyData = Random.Range(0, _meleeEnemies.Length);

		return GetEnemyFromPool(_meleeEnemies[randomMeleeEnemyData].EnemyPool);
	}

	private Enemy GetRangedEnemy()
	{
		int randomRangedEnemyData = Random.Range(0, _rangedEnemies.Length);
		
		return GetEnemyFromPool(_rangedEnemies[randomRangedEnemyData].EnemyPool);
	}
	
	private Enemy GetEnemyFromPool(PoolType enemyPool)
	{
		GameObject enemyObject = ObjectPooler.GetObjectFromPool(enemyPool);
		
		Enemy enemy = enemyObject.GetComponent<Enemy>();
		
		return enemy;
	}

	public Transform[] GetRangedEnemySpawnPoints()
	{
		return _rangedEnemySpawnPoints;
	}

	public void SetRangedSpawnIndex(int newIndex)
	{
		_rangedSpawnPointIndex = newIndex;
	}
}
