using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public List<Stat> defaultStats = new List<Stat>();
    public Dictionary<StatType, Stat> stats = new Dictionary<StatType, Stat>();

    public bool statsInitialized = false;



    public Stat GetStat(StatType type)
    {
        return stats.ContainsKey(type) ? stats[type] : null;
    }

    public float GetStatValue(StatType type)
    {
        Stat stat = GetStat(type);

        return stat != null ? stat.GetValue() : 0;
    }

    public virtual void Awake()
    {
        var statTypes = Enum.GetValues(typeof(StatType));

        foreach (StatType type in statTypes) {           
            stats.Add(type, new Stat(type));
        }

        foreach (Stat stat in defaultStats)
        {
            if (stats.ContainsKey(stat.type))
            {
                stats[stat.type].baseValue = stat.baseValue;
            }
        }

        statsInitialized = true;
    }
}
