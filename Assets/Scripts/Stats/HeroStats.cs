using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : CharacterStats
{
	public override void Awake()
	{
		base.Awake();
		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

	void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if (newItem != null)
		{
			foreach(StatModifier statModifier in newItem.modifiers)
			{
				if (stats.ContainsKey(statModifier.statType))
				{
					stats[statModifier.statType].AddModifier(statModifier.modifier);
				}
			}
		}

		if (oldItem != null)
		{
			foreach (StatModifier statModifier in oldItem.modifiers)
			{
				if (stats.ContainsKey(statModifier.statType))
				{
					stats[statModifier.statType].RemoveModifier(statModifier.modifier);
				}
			}
		}

	}
}
