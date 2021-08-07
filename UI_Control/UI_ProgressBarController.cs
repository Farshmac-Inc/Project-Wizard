using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ProgressBarController : MonoBehaviour
{
    [SerializeField] private SkillIcon[] skillIcons;
    [SerializeField] private ManaProgressBar[] manaProgressBars = new ManaProgressBar[3];
    [SerializeField] private SkillManager skillManager;
    
    private void Start()
    {
        foreach (var pool in skillManager.ManaPools)
        {
            pool.ChangeCurrentValue += ChangeProgressBar;
        }        
    }

    private void ChangeProgressBar(ManaType _type, float _newValue, float _maxValue)
    {
        UpdateProgressBar(Array.Find(manaProgressBars, bar => bar.manaType == _type).progresseBar, _newValue, _maxValue);
    }

    private void UpdateProgressBar(Slider progressBar, float _newValue, float _maxValue)
    {
        progressBar.value = _newValue  / _maxValue;
        progressBar.GetComponentInChildren<Text>().text = $"{_newValue}/{_maxValue}";
    }
}
