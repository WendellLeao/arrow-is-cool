using UnityEngine;

[RequireComponent(typeof(PlayerInputsListener), typeof(CharacterController))]
public sealed class PlayerJump : Player
{
	[Header("Player Components")]
	[SerializeField] private CharacterController _characterController;
	
	[Header("Check Ground")]
	[SerializeField] private LayerMask _groundMask;

	[SerializeField] private float _raycastDistance = 1.1f;
	
	[Header("Jump")]
	[SerializeField] private float _jumpForce = 1.5f;

	[Header("Gravity")]
	[SerializeField] private float _fallSpeed = 20f;

	private float _verticalVelocity;

	private bool _canJump = false;
	
	protected override void AddEventListeners()
	{
		base.AddEventListeners();
		
		_globalGameEvents.OnGameStateChanged += OnGameStateChanged_CheckIfCanJump;
		
		_localGameEvents.OnReadPlayerInputs += OnReadPlayerInputs_HandleVerticalMovement;
	}
	
	protected override void RemoveEventListeners()
	{
		base.RemoveEventListeners();
		
		_globalGameEvents.OnGameStateChanged -= OnGameStateChanged_CheckIfCanJump;
		
		_localGameEvents.OnReadPlayerInputs -= OnReadPlayerInputs_HandleVerticalMovement;
	}

	private void OnGameStateChanged_CheckIfCanJump(GameState gameState)
	{
		SetCanJump(gameState == GameState.PLAYING);
	}

	private void OnReadPlayerInputs_HandleVerticalMovement(PlayerInputsData playerInputsData)
	{
		if (IsGrounded())
		{
			SetVerticalVelocity(0.0f);

			if (playerInputsData.IsJumping && _canJump)
			{
				SoundManager.PlaySound(Sound.PLAYER_JUMP, transform.position);
				
				SetVerticalVelocity(Mathf.Sqrt(_jumpForce * -2f * -_fallSpeed));
			}
		}
		
		SetVerticalVelocity(_verticalVelocity += -_fallSpeed * Time.deltaTime);

		_characterController.Move(_verticalVelocity * Vector3.up * Time.deltaTime);
	}

	private bool IsGrounded()
	{
		Vector3 playerPosition = transform.position;

		return Physics.Raycast(playerPosition, Vector3.down, _raycastDistance, _groundMask);
	}
	
	private void SetVerticalVelocity(float velocity)
	{
		_verticalVelocity = velocity;
	}

	private void SetCanJump(bool canJump)
	{
		_canJump = canJump;
	}
}
