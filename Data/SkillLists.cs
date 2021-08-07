using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Type = Pooler_Types.SkillObjectInfo.ObjectType;

public static class SkillList
{
    public static List<SkillParam> Skills = new List<SkillParam>()
    {
        new Throwing("FireBall", new List<ManaTypeCast>(){ new ManaTypeCast(ManaType.Energy, 20)}, Type.FireBall),
        new Summon("StoneStalagmitem" , new List<ManaTypeCast>(){ new ManaTypeCast(ManaType.Matter, 20)}, Type.StoneStalagmite)
    };

    public static void RemoveFromList(string _skillName)
    {
        for (int i = 0; i < Skills.Count; i++)
        {
            if (Skills[i].SkillName == _skillName)
            {
                Skills.RemoveAt(i);
                return;
            }
        }
    }

    public static void AddSkillThrowing(string _skillName, ManaTypeCast _typeCast, Type _type)
    {
        Skills.Add(new Throwing(_skillName, new List<ManaTypeCast>() { _typeCast }, _type));
    }
    public static void AddSkillThrowing(string _skillName, ManaTypeCast[] _typeCast, Type _type)
    {
        Skills.Add(new Throwing(_skillName, _typeCast.ToList(), _type));
    }
    public static void AddSkillThrowing(string _skillName, List<ManaTypeCast> _typeCast, Type _type)
    {
        Skills.Add(new Throwing(_skillName, _typeCast, _type));
    }
}

