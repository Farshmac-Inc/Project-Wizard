using UnityEngine;

[System.Serializable]
public struct Resistance
{
    public ManaType ResistanceType;
    [Range(0f, 1f)] public float Value;

    public Resistance(ManaType _resistanceType, float _value)
    {
        ResistanceType = _resistanceType;
        Value = _value;
    }
}

