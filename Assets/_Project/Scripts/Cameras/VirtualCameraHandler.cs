using UnityEngine;
using Cinemachine;

public sealed class VirtualCameraHandler : MonoBehaviour
{
	[Header("Game Events")]
	[SerializeField] private GlobalGameEvents _globalGameEvents;

	[Header("Virtual Camera")]
	[SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
	
    	private void OnEnable()
    	{
    		AddEventListeners();
    	}
    	
    	private void OnDisable()
    	{
    		RemoveEventListeners();
    	}

      private void AddEventListeners()
      {
	      _globalGameEvents.OnGameStateChanged += OnGameStateChanged_HandleVirtualCamera;
      }

      private void RemoveEventListeners()
      {
	      _globalGameEvents.OnGameStateChanged -= OnGameStateChanged_HandleVirtualCamera;
      }

      private void OnGameStateChanged_HandleVirtualCamera(GameState gameState)
      {
	      if (gameState != GameState.PLAYING && gameState != GameState.STARTING)
	      {
		      _cinemachineVirtualCamera.enabled = false;
	      }
	      else
	      {
		      _cinemachineVirtualCamera.enabled = true;
	      }
      }
}
