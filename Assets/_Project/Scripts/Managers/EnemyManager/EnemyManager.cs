using Random = UnityEngine.Random;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public sealed class EnemyManager : GameManager
{
	[Header("Enemy Spawner")]
	[SerializeField] private EnemySpawner _enemySpawner;
	
	[Header("Player Posistion")]
	[SerializeField] private Transform _playerTransform;
	
	private Dictionary<Transform, Enemy> _spawnPointDictionary = new Dictionary<Transform, Enemy>();
	
	private List<Enemy> _enemiesInScene = new List<Enemy>();
	
	private Transform[] _rangedEnemySpawnPoints;

	private int _maximumEnemiesInScene, _enemiesDefeatedAmount;

	private float _spawnRate;
	
	protected override void AddEventListeners()
	{
		_globalGameEvents.OnGameIsFinished += OnGameIsFinished_RaiseTotalEnemiesDefeatedAmount;
	}

	protected override void RemoveEventListeners()
	{
		_globalGameEvents.OnGameIsFinished -= OnGameIsFinished_RaiseTotalEnemiesDefeatedAmount;
	}

	protected override void Initialize()
	{
		base.Initialize();

		SetRangedEnemySpawnPoints(_enemySpawner.GetRangedEnemySpawnPoints());

		StartCoroutine(SpawnEnemies());
		
		SetMaximumEnemiesInScene(SaveSystem.GetLocalGameData().MaximumEnemiesInScene);

		SetSpawnRate(SaveSystem.GetLocalGameData().EnemiesSpawnRate);
	}

	private void Update()
	{
		UpdateEnemies();
	}
	
	private IEnumerator SpawnEnemies()
	{
		yield return new WaitForSeconds(_spawnRate);
		
		if (CanSpawnMeleeEnemy())
		{
			SpawnMeleeEnemy();
		}

		yield return new WaitForSeconds(_spawnRate);
		
		if (CanSpawnRangedEnemy())
		{
			SpawnRangedEnemy();
		}

		StartCoroutine(SpawnEnemies());
	}

	private void SpawnMeleeEnemy()
	{
		Enemy spawnedMeleeEnemy = _enemySpawner.SpawnMeleeEnemy();	
		
		_enemiesInScene.Add(spawnedMeleeEnemy);
	}

	private void SpawnRangedEnemy()
	{
		int rangedSpawnPointIndex = Random.Range(0, _rangedEnemySpawnPoints.Length);

		if (!_spawnPointDictionary.TryGetValue(_rangedEnemySpawnPoints[rangedSpawnPointIndex], out Enemy enemy))
		{
			_enemySpawner.SetRangedSpawnIndex(rangedSpawnPointIndex);
			
			Enemy spawnedRangedEnemy = _enemySpawner.SpawnRangedEnemy();

			_spawnPointDictionary.Add(_rangedEnemySpawnPoints[rangedSpawnPointIndex], spawnedRangedEnemy);
				
			_enemiesInScene.Add(spawnedRangedEnemy);
		}
	}
	
	private void UpdateEnemies()
	{
		for (int i = 0; i < _enemiesInScene.Count; i++)
		{
			_enemiesInScene[i].SetPlayerPosition(_playerTransform.position);
			
			CheckEnemyState(i);
		}
	}

	private void CheckEnemyState(int index)
	{
		if (_enemiesInScene[index].GetEnemyState() == EnemyState.DEAD)
		{
			_enemiesDefeatedAmount++;
				
			CheckUnusedRangedEnemySpawnPoint(index);
				
			_enemiesInScene.Remove(_enemiesInScene[index]);
		}
	}

	private void CheckUnusedRangedEnemySpawnPoint(int index)
	{
		Transform[] rangedEnemySpawnPoints = _enemySpawner.GetRangedEnemySpawnPoints();
		
		for (int j = 0; j < rangedEnemySpawnPoints.Length; j++)
		{
			if(_spawnPointDictionary.TryGetValue(rangedEnemySpawnPoints[j], out Enemy enemy))
			{
				if (enemy == _enemiesInScene[index])
				{
					_spawnPointDictionary.Remove(rangedEnemySpawnPoints[j]);
				}
			}
		}
	}
	
	private void OnGameIsFinished_RaiseTotalEnemiesDefeatedAmount()
	{
		_globalGameEvents.OnRaseEnemiesDefeated?.Invoke(_enemiesDefeatedAmount);
	}

	private bool CanSpawnMeleeEnemy()
	{
		return _enemiesInScene.Count < _maximumEnemiesInScene;
	}

	private bool CanSpawnRangedEnemy()
	{
		return _spawnPointDictionary.Count <= _rangedEnemySpawnPoints.Length;
	}

	private void SetRangedEnemySpawnPoints(Transform[] rangedEnemySpawnPoints)
	{
		_rangedEnemySpawnPoints = rangedEnemySpawnPoints;
	}

	private void SetMaximumEnemiesInScene(int maximumEnemies)
	{
		_maximumEnemiesInScene = maximumEnemies;
	}

	private void SetSpawnRate(float spawnRate)
	{
		_spawnRate = spawnRate;
	}
}
