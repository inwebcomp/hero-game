using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPoint : Collectable
{
    public enum Type { Full, Percent, Amount };

    public Type type = Type.Full; 

    public int amount;

    [Range(0, 1f)]
    [SerializeField]
    public float percent;

    protected override bool Collect(GameObject collector)
    {
        Character character = collector.GetComponent<Character>();

        if (type == Type.Full)
        {
            character.Heal();
        }
        else if (type == Type.Percent)
        {
            character.Heal(Mathf.RoundToInt(character.maxHealth * percent));
        }
        else if (type == Type.Amount)
        {
            character.Heal(amount);
        }

        return true;
    }

    public override void ApplyRarity(float rarity)
    {
        base.ApplyRarity(rarity);

        if (type == Type.Amount)
        {
            amount = Mathf.RoundToInt(amount * (1 + rarity));
        }
    }
}
