using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    public int amount;

    protected override bool Collect(GameObject collector)
    {
        HeroManager.instance.AddMoney(amount);

        return true;
    }

    public override void ApplyRarity(float rarity)
    {
        base.ApplyRarity(rarity);

        amount = Mathf.RoundToInt(amount * (1 + rarity)); 
    }
}
