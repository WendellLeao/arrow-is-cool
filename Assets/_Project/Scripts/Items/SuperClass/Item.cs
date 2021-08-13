using UnityEngine;

public abstract class Item : MonoBehaviour
{
	protected abstract void OnTriggerEnter(Collider other);

	protected abstract void ReturnItemToPool();

	protected virtual void OnDisable()
	{
		ReturnItemToPool();
	}

	protected void DeactivateObject()
	{
		this.gameObject.SetActive(false);
	}
}
