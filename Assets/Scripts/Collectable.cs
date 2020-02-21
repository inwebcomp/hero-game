using System.Collections;
using System.Collections.Generic;
using UnityEngine;
abstract public class Collectable : MonoBehaviour
{
    public string canCollect = "Hero";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(canCollect))
        {
            if (Collect(collision.gameObject))
                Disappear();
        }
    }

    protected void Disappear()
    {
        Destroy(gameObject);
    }

    abstract protected bool Collect(GameObject collector);

    virtual public void ApplyRarity(float rarity)
    {
        //
    }
}
