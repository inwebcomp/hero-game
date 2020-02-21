using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
	public Transform itemsParent;   // The parent object of all the items

	EquipmentManager equipment;    // Our current equipment

	EquipmentSlot[] slots;  // List of all the slots

	void Start()
	{
		equipment = EquipmentManager.instance;
		equipment.onEquipmentChanged += UpdateUI;    // Subscribe to the onEquipmentChanged callback

		// Populate our slots array
		slots = itemsParent.GetComponentsInChildren<EquipmentSlot>();
	}

	// Update the equipment UI by:
	//		- Adding items
	//		- Clearing empty slots
	// This is called using a delegate on the Inventory.
	void UpdateUI(Equipment newItem, Equipment oldItem)
	{
		// Loop through all the slots
		for (int i = 0; i < slots.Length; i++)
		{
			if (equipment.currentEquipment[i])  // If there is an item to add
			{
				slots[i].AddItem(equipment.currentEquipment[i]);   // Add it
			}
			else
			{
				// Otherwise clear the slot
				slots[i].ClearSlot();
			}
		}
	}
}
