using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int level = 1;

    [Header("Health")]
    public bool isMortal = true;
    public bool takeForce = true;
    public int health = 10;
    public int maxHealth = 10;
    public Slider hpBar;

    [Header("Movement")]
    public bool canMove = true;
    public float moveSpeed = 10f;
    [Range(0, .3f)]
    [SerializeField]
    protected float m_MovementSmoothing = .05f;

    [HideInInspector]
    public Rigidbody2D rigidbody2d;
    protected Vector3 m_Velocity = Vector3.zero;

    [Header("Power")]
    public bool dealDamage = true;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        EquipmentManager.instance.onEquipmentChanged += UpdateUIOnEquipmentChanged;

        AwakeUpdateStats();
        AwakeUpdateUI();
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            float direction = Input.GetAxisRaw("Horizontal");
            Vector3 targetVelocity = new Vector2(direction * moveSpeed * 10 * Time.fixedDeltaTime, rigidbody2d.velocity.y);
            rigidbody2d.velocity = Vector3.SmoothDamp(rigidbody2d.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }
    }

    /**
     * @return bool If character died
     */
    public bool TakeDamage(float amount)
    {
        if (!isMortal)
            return false;

        int damage = Mathf.RoundToInt(amount);

        health -= damage;

        Debug.Log(gameObject.name + " taking " + damage.ToString() + " damage");

        UpdateUI();

        if (health <= 0)
        {
            health = 0;
            Die();
            return true;
        }

        return false;
    }

    virtual protected void BeforeDie()
    {
        //
    }

    protected void Die()
    {
        BeforeDie();
        Destroy(gameObject);
    }

    virtual protected void AwakeUpdateStats()
    {
        if (this == null)
            return;

        CharacterStats stats = GetComponent<CharacterStats>();

        if (stats && stats.statsInitialized)
        {
            maxHealth = (int) stats.GetStatValue(StatType.Health);
            health = maxHealth;

            moveSpeed *= (float) stats.GetStatValue(StatType.Speed);
        }
    }

    virtual protected void AwakeUpdateUI()
    {
        if (hpBar)
        {
            hpBar.maxValue = maxHealth;
            hpBar.value = health;
        }
    }

    virtual protected void UpdateUIOnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        AwakeUpdateStats();
        UpdateUI();
    }

    virtual protected void UpdateUI()
    {
        if (hpBar)
        {
            hpBar.maxValue = maxHealth;
            hpBar.value = health;
        }
    }

    public void TakeForce(Vector2 direction, float amount = 1000f)
    {
        if (!takeForce)
            return;

        rigidbody2d.velocity = Vector2.zero;
        rigidbody2d.AddForce(direction * amount);
    }

    public void Heal()
    {
        Heal(maxHealth);
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
        UpdateUI();
    }
}
