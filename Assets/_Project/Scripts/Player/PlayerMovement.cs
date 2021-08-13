using UnityEngine;

[RequireComponent(typeof(PlayerInputsListener), typeof(CharacterController))]
public sealed class PlayerMovement : Player
{
	[Header("Player Components")]
	[SerializeField] private CharacterController _characterController;
	
	[Header("Movement")]
	[SerializeField] private float _moveSpeed = 4.5f;
	
	[Range(0.0f, 0.5f)]
	[SerializeField] private float _moveSmothTime = 0.2f;

	private Vector2 _currentDirection, _currentDirectionVelocity;

	protected override void AddEventListeners()
	{
		base.AddEventListeners();
		
		_localGameEvents.OnReadPlayerInputs += OnReadPlayerInputs_HandleHorizontalMovement;
	}

	protected override void RemoveEventListeners()
	{
		base.RemoveEventListeners();
		
		_localGameEvents.OnReadPlayerInputs -= OnReadPlayerInputs_HandleHorizontalMovement;
	}

	private void OnReadPlayerInputs_HandleHorizontalMovement(PlayerInputsData playerInputsData)
	{
		Transform playerTransform = transform; 
		
		Vector2 smoothDirection = GetSmoothDirection(playerInputsData.PlayerMovement.normalized);
		
		Vector3 velocity = (playerTransform.right * smoothDirection.x) + (playerTransform.forward * smoothDirection.y);

		_characterController.Move(velocity * _moveSpeed * Time.deltaTime);
	}

	private Vector2 GetSmoothDirection(Vector2 targetDirection)
	{
		return _currentDirection = Vector2.SmoothDamp(_currentDirection, targetDirection, 
			ref _currentDirectionVelocity, _moveSmothTime);
	}
}
