using UnityEngine;

public class ItemPickup : Collectable {

	public Item item;   // Item to put in the inventory on pickup

	protected override bool Collect(GameObject collector)
	{
		Debug.Log("Picking up " + item.name);

		return Inventory.instance.Add(item);    // Add to inventory
	}
}
