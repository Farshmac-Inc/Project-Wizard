[System.Serializable]
public struct Damage
{
    public ManaType DamageType;
    public float Value;

    public Damage(ManaType resistanceType, float value)
    {
        DamageType = resistanceType;
        Value = value;
    }
}

