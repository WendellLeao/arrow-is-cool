using UnityEngine;

public sealed class ItemDropper
{
	[Header("Item")]
	private GameObject _randomDroppedItem;
	
	public void DropRandomItem()
	{
		int itemTypeEnumLenght = System.Enum.GetValues(typeof(ItemType)).Length;
		
		ItemType itemType = (ItemType)Random.Range(0, itemTypeEnumLenght);

		switch (itemType)
		{
			case ItemType.NULL:
			{
				_randomDroppedItem = null;
				break;
			}
			case ItemType.HEALTH:
			{
				_randomDroppedItem = ObjectPooler.GetObjectFromPool(PoolType.HEALTH_ITEM);
				break;
			}
			case ItemType.ARROW:
			{
				_randomDroppedItem = ObjectPooler.GetObjectFromPool(PoolType.ARROW_ITEM);
				break;
			}
		}
	}

	public void SetDroppedItemPosition(Vector3 newPosition)
	{
		if (_randomDroppedItem != null)
		{
			Vector3 droppedItemPosition = _randomDroppedItem.transform.position;
			Vector3 newDroppedItemPosition = new Vector3(newPosition.x, droppedItemPosition.y, newPosition.z);
			
			_randomDroppedItem.transform.position = newDroppedItemPosition;
		}
	}
}
