using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroManager : MonoBehaviour
{
    public static HeroManager instance;

    private int _money;

    public int money {
        get { return _money; }
        set { 
            _money = value;
            moneyText.text = money.ToString();
        }
    }

    public TextMeshProUGUI moneyText;

    void Awake()
    {
        instance = this;

        AwakeUpdateUI();
    }

    void AwakeUpdateUI()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (moneyText)
        {
            moneyText.text = money.ToString();
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }
}