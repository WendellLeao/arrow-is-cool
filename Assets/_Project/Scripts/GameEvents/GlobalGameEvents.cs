using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Events/Global Game Events")]
public sealed class GlobalGameEvents : ScriptableObject
{
    public UnityAction<GameState> OnGameStateChanged;
    
    public UnityAction<int> OnRaseEnemiesDefeated;

    public UnityAction<bool> OnGameIsPaused;
    
    public UnityAction OnGameIsFinished;
    
    public UnityAction OnGameIsStarted;
    
    public UnityAction OnPlayerDied;
}
