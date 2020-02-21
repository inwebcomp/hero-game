using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> enemies;
    public HealPoint healPoint;

    public int difficulty = 1;
    public int chunks = 3;
    public int chunkSize = 5;
    public float spaceBetweenEnemies = 3f;
    public float spaceBetweenChunks = 20f;

    void Awake()
    {
        Vector2 position = transform.position;

        for (int chunk = 0; chunk < chunks; chunk++)
        {
            for (int i = 0; i < chunkSize; i++)
            {
                Instantiate(enemies[0], position, Quaternion.identity, transform);
                position.x += spaceBetweenEnemies;
            }

            position.x += spaceBetweenChunks / 2;

            Instantiate(healPoint, position, Quaternion.identity, transform);

            position.x += spaceBetweenChunks / 2;
        }
    }
}
