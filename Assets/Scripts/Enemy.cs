using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    override protected void BeforeDie()
    {
        DropSystem.instance.Drop(this);
    }
}
