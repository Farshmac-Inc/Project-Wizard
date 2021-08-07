[System.Serializable]
public struct ManaTypeCast
{
    public ManaType Type;
    public float ManaCost;

    public ManaTypeCast(ManaType _type, float _manaCost)
    {
        Type = _type;
        ManaCost = _manaCost;
    }
}
