using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Hero : Character
{
    [Header("Experience")]
    public int xp = 0;
    public int maxXp = 10;
    public Slider xpBar;

    protected override void AwakeUpdateUI()
    {
        base.AwakeUpdateUI();

        if (xpBar)
        {
            xpBar.maxValue = maxXp;
            xpBar.value = xp;
        }
    }

    protected override void UpdateUI()
    {
        base.UpdateUI();

        if (xpBar)
        {
            xpBar.value = xp;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dealDamage)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Enemy enemy = collision.GetComponent<Enemy>();

                if (enemy.dealDamage)
                {
                    TakeDamage(enemy.GetComponent<CharacterStats>().GetStatValue(StatType.Damage));
                }

                if (! enemy.TakeDamage(GetComponent<CharacterStats>().GetStatValue(StatType.Damage)))
                {
                    TakeForce(Vector2.left, 1000f);
                    enemy.TakeForce(Vector2.right, 250f);
                } else
                {
                    GetXpForEnemy(enemy);
                }
            }
        }
    }

    private void GetXpForEnemy(Enemy enemy)
    {
        xp += enemy.level;

        if (xp >= maxXp)
        {
            xp = maxXp - xp;
            LevelUp();
        }

        UpdateUI();
    }

    private void LevelUp()
    {
        level++;
        maxXp *= (int)Mathf.Pow(1.2f, level - 1);
    }

    void OnValidate()
    {
        UpdateUI();
    }
}
