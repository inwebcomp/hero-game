using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSystem : MonoBehaviour
{
    public static DropSystem instance;

    public List<Rigidbody2D> items;

    public float dropPower = 20f;

    void Awake()
    {
        instance = this;
    }

    public Collectable Drop(Enemy enemy)
    {
        return DropFromPosition(enemy.transform.position);
    }

    public Collectable DropFromPosition(Vector2 position, float rarity = 0f)
    {
        if (items.Count == 0)
            return null;

        Rigidbody2D body = Instantiate(items[Random.Range(0, items.Count - 1)], position, Quaternion.identity);

        body.AddForce(new Vector2(Random.Range(0.4f, 0.8f), Random.Range(0.6f, 1f)) * dropPower);

        body.GetComponent<Collectable>().ApplyRarity(rarity);

        return body.gameObject.GetComponent<Collectable>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DropFromPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
