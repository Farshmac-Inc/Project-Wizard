using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class SkillParam
{
    public string SkillName;
    public List<ManaTypeCast> UsedMana;
    public Pooler_Types.SkillObjectInfo.ObjectType Type;
    protected SkillParam(string _skillName, List<ManaTypeCast> _usedMana, Pooler_Types.SkillObjectInfo.ObjectType _type )
    {
        SkillName = _skillName;
        UsedMana = _usedMana;
        Type = _type;
    }

    public abstract void UsedSkill(Vector3 _startPoint, Vector3 _endPoint);
}
