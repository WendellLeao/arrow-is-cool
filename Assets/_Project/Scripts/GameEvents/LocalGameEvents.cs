using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Events/Local Game Events")]
public sealed  class LocalGameEvents : ScriptableObject
{
    public UnityAction<PlayerInputsData> OnReadPlayerInputs;
    
    public UnityAction<int, int> OnHealthChanged;

    public UnityAction<int> OnGameTimeChanged;
    
    public UnityAction<int> OnScoreChanged;

    public UnityAction<int> OnAmmoChanged;
    
    public UnityAction OnPlayerIsDamaged;
}
