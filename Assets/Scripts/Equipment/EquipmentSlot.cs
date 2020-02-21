using UnityEngine;
using UnityEngine.UI;

/* Sits on all EquipmentSlots. */

public class EquipmentSlot : MonoBehaviour
{
	public Image icon;          // Reference to the Icon image

	Equipment equipment;  // Current equipment in the slot

	// Add item to the slot
	public void AddItem(Equipment newEquipment)
	{
		equipment = newEquipment;

		icon.sprite = equipment.icon;
		icon.enabled = true;
	}

	// Clear the slot
	public void ClearSlot()
	{
		equipment = null;

		icon.sprite = null;
		icon.enabled = false;
	}

	// Called when the item is pressed
	public void UnequipItem()
	{
		if (equipment != null)
		{
			EquipmentManager.instance.Unequip(transform.GetSiblingIndex());
		}
	}
}
