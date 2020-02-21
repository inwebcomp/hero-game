using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class UIStat : MonoBehaviour
{
    public string title;

    public float _value;

    public float value
    {
        get { return _value; }
        set
        {
            _value = value;
            UpdateUI();
        }
    }

    public StatType statType = StatType.None;

    public CharacterStats stats;

    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += UpdateUIOnEquipmentChanged;
        UpdateStat();
    }

    virtual protected void UpdateUIOnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        UpdateStat();
    }

    void UpdateStat()
    {
        if (statType != StatType.None && stats.statsInitialized)
        {
            value = stats.GetStatValue(statType);
        }
    }

    private void UpdateUI()
    {
        if (!text)
            return;

        text.text = this.title + ": " + this.value.ToString();
    }

    void OnValidate()
    {
        UpdateUI();
    }
}
