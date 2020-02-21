using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* An Item that can be equipped. */

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {
	
	public EquipmentSlotType equipSlot;	// Slot to store equipment in

	public float armorModifier;		// Increase/decrease in armor
	public float damageModifier;      // Increase/decrease in damage

	public Sprite sprite;

	// When pressed in inventory
	public override void Use()
	{
		base.Use();
		EquipmentManager.instance.Equip(this);	// Equip it
		RemoveFromInventory();					// Remove it from inventory
	}

}

public enum EquipmentSlotType { Head, Chest, Legs, Weapon, Shield, Feet }
