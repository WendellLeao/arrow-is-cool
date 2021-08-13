using UnityEngine.InputSystem;
using UnityEngine;

public sealed class PlayerInputsListener : Player
{
	[Header("Input System")]
	private PlayerInputs _playerInputs;
	
	private PlayerInputs.LandControlsActions _playerLandControls;

	[Header("Inputs Data")]
	private Vector2 _playerMovement;

	private bool _isShooting, _isAiming, _isJumping, _pressPause;
	
	protected override void OnEnable()
	{
		base.OnEnable();
		
		EnablePlayerInputs();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		
		DisablePlayerInputs();
	}
	
	protected override void Initialize()
	{
		base.Initialize();
		
		InitializePlayerInputs();
	}
	
	protected override void AddEventListeners()
	{
		base.AddEventListeners();
		
		_playerLandControls.Shoot.performed += OnShoot_SetIsShooting;
		_playerLandControls.Shoot.canceled += OnShoot_SetIsShooting;

		_playerLandControls.Aim.performed += OnShoot_SetIsAiming;
		_playerLandControls.Aim.canceled += OnShoot_SetIsAiming;
		
		_playerLandControls.Jump.performed += OnJump_SetIsJumping;
		_playerLandControls.Jump.canceled += OnJump_SetIsJumping;
		
		_playerLandControls.Movement.performed += SetPlayerMovement;

		_playerInputs.Global.PauseGame.performed += OnPauseGame_SetPressPause;
		_playerInputs.Global.PauseGame.canceled += OnPauseGame_SetPressPause;
	}

	protected override void RemoveEventListeners()
	{
		base.RemoveEventListeners();
		
		_playerLandControls.Shoot.performed -= OnShoot_SetIsShooting;
		_playerLandControls.Shoot.canceled -= OnShoot_SetIsShooting;
		
		_playerLandControls.Aim.performed -= OnShoot_SetIsAiming;
		_playerLandControls.Aim.canceled -= OnShoot_SetIsAiming;
		
		_playerLandControls.Jump.performed -= OnJump_SetIsJumping;
		_playerLandControls.Jump.canceled -= OnJump_SetIsJumping;
		
		_playerLandControls.Movement.performed -= SetPlayerMovement;
		
		_playerInputs.Global.PauseGame.performed -= OnPauseGame_SetPressPause;
		_playerInputs.Global.PauseGame.canceled -= OnPauseGame_SetPressPause;
	}
	
	private void Update()
	{
		UpdatePlayerInputs();
		
		ResetInputs();
	}

	private void InitializePlayerInputs()
	{
		_playerInputs = new PlayerInputs();
		
		_playerLandControls = _playerInputs.LandControls;
	}
	
	private void EnablePlayerInputs()
	{
		_playerInputs.Enable();
	}
	
	private void DisablePlayerInputs()
	{
		_playerInputs.Disable();
	}
	
	private void UpdatePlayerInputs()
	{
		_localGameEvents.OnReadPlayerInputs?.Invoke(SetPlayerInputsData());
	}
	
	private void ResetInputs()
	{
		_pressPause = false;
	}
	
	private void OnJump_SetIsJumping(InputAction.CallbackContext context)
	{
		switch(context.phase)
		{
			case InputActionPhase.Performed:
			{
				_isJumping = true;
				break;
			}
			case InputActionPhase.Canceled:
			{
				_isJumping = false;
				break;
			}
		}
	}
	
	private void OnShoot_SetIsShooting(InputAction.CallbackContext context)
	{
		switch(context.phase)
		{
			case InputActionPhase.Performed:
			{
				_isShooting = true;
				break;
			}
			case InputActionPhase.Canceled:
			{
				_isShooting = false;
				break;
			}
		}
	}
	
	private void OnShoot_SetIsAiming(InputAction.CallbackContext context)
	{
		switch(context.phase)
		{
			case InputActionPhase.Performed:
			{
				_isAiming = true;
				break;
			}
			case InputActionPhase.Canceled:
			{
				_isAiming = false;
				break;
			}
		}
	}
	
	private void OnPauseGame_SetPressPause(InputAction.CallbackContext context)
	{
		switch(context.phase)
		{
			case InputActionPhase.Performed:
			{
				_pressPause = true;
				break;
			}
			case InputActionPhase.Canceled:
			{
				_pressPause = false;
				break;
			}
		}
	}
	
	private PlayerInputsData SetPlayerInputsData()
	{
		PlayerInputsData playerInputsData = new PlayerInputsData();

		playerInputsData.PlayerMovement = _playerMovement;
		playerInputsData.PressPause = _pressPause;
		playerInputsData.IsShooting = _isShooting;
		playerInputsData.IsJumping = _isJumping;
		playerInputsData.IsAiming = _isAiming;

		return playerInputsData;
	}

	private void SetPlayerMovement(InputAction.CallbackContext action)
	{
		_playerMovement = action.ReadValue<Vector2>();
	}
}
