﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_SkillsIconController : MonoBehaviour
{

    public event Action<int> SelectSkill;

    [SerializeField] private SkillIcon[] skillIcons;
    [SerializeField] private SkillManager skillManager;

}
