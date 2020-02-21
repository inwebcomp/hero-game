using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
	public StatType type;
	public float baseValue;   // Starting value

	// Keep a list of all the modifiers on this stat
	private List<float> modifiers = new List<float>();

	public Stat(StatType type, float baseValue = 0f)
	{
		this.type = type;
		this.baseValue = baseValue;
	}

	// Add all modifiers together and return the result
	public float GetValue()
	{
		float finalValue = baseValue;
		modifiers.ForEach(x => finalValue += x);
		return finalValue;
	}

	// Add a new modifier to the list
	public void AddModifier(float modifier)
	{
		if (modifier != 0)
			modifiers.Add(modifier);
	}

	// Remove a modifier from the list
	public void RemoveModifier(float modifier)
	{
		if (modifier != 0)
			modifiers.Remove(modifier);
	}
}

public enum StatType { 
	None,
	Health, 
	Damage, 
	Armor,
	Speed,
}
