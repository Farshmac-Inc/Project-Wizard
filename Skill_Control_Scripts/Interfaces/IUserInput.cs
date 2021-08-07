using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserInput
{
    public event Action<Vector3> PointCick;
    public event Action<int> SkillSelect;

}
