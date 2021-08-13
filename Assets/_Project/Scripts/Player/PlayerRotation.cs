using UnityEngine;

public sealed class PlayerRotation : MonoBehaviour
{
	[Header("Camera")]
	[SerializeField] private Transform _cameraTransform;

	[Header("Rotation")]
	[SerializeField] private float _rotationSpeed = 5f;
	
	private void Update()
	{
		RotateTowardsCameraDirection();
	}

	private void RotateTowardsCameraDirection()
	{
		Quaternion targetRotation = Quaternion.Euler(0f, _cameraTransform.eulerAngles.y, 0f);
		
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
	}
}
