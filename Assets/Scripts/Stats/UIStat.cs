using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class UIStat : MonoBehaviour
{
    public string title;

    public string _value;

    public string value
    {
        get { return _value; }
        set
        {
            _value = value;
            UpdateUI();
        }
    }

    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateUI()
    {
        text.text = this.title + ": " + this.value.ToString();
    }

    void OnValidate()
    {
        UpdateUI();
    }
}
