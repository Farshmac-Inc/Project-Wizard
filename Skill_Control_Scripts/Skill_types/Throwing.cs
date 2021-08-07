using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Throwing : SkillParam
{
    public Throwing(string _skillName, List<ManaTypeCast> _usedMana, Pooler_Types.SkillObjectInfo.ObjectType _type)
        : base(_skillName, _usedMana, _type) { }

    public override void UsedSkill(Vector3 _startPoint, Vector3 _endPoint)
    {
        var _obj = SkillObjectPooler.ObjectPool.GetSkillObject(Type);
        var _temp = _obj.GetComponent<SkillObjectTemplate>();

        _temp.Spawn(_startPoint, _endPoint);
        _temp.StartCoroutine(_temp.TimeToDeathCounter());
        _temp.InternalService();

    }
}