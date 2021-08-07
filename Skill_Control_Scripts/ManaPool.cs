using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ManaPool
{
    public delegate void ChangeParametrs(ManaType typeName,float currentValue, float maxValue);
    public event ChangeParametrs ChangeMaxCount;
    public event ChangeParametrs ChangeCurrentValue;
    public event ChangeParametrs ChangeRegeneration;
    public event ChangeParametrs ChangeManaCostCoef;
    public ManaType TypeName;

    [SerializeField] private float currentValue;
    [Space]
    [SerializeField] [Range(0f, 100f)] private float regeneration;
    [SerializeField] [Range(0f, 5f)] private float manaCostCoef;
    [SerializeField] [Range(0, 1000)] private float maxValue;

    public ManaPool(ManaType _name, float _maxValue, float _regeneration, float _manaCostCoef)
    {
        ChangeMaxCount = null;
        ChangeCurrentValue = null;
        ChangeRegeneration = null;
        ChangeManaCostCoef = null;
        TypeName = _name;
        currentValue = _maxValue;
        this.maxValue = _maxValue;
        this.regeneration = _regeneration;
        this.manaCostCoef = _manaCostCoef;
    }
    public void SetRegeneration(float _newValue)
    {
        regeneration = _newValue;
        ChangeRegeneration?.Invoke(TypeName, _newValue, maxValue);
    }
    public void SetMaxCount(float _newValue)
    {
        if (_newValue > 0)
        {
            maxValue = _newValue;
            ChangeMaxCount?.Invoke(TypeName, _newValue, maxValue);
        }
    }
    public void SetManaCostCoef(float _newValue)
    {
        manaCostCoef = _newValue;
        ChangeManaCostCoef?.Invoke(TypeName, _newValue, maxValue);
    }

    public bool CheckRequiredAmountMana(float _manaCost)
    {
        if ((currentValue - _manaCost * manaCostCoef) >= 0) return true;
        else return false;
    }
    public void SpendMana(float _manaCost)
    {
        currentValue -= _manaCost * manaCostCoef;
        ChangeCurrentValue?.Invoke(TypeName, currentValue, maxValue);
    }
    public void RegerateMana()
    {
        if (currentValue < maxValue) RegerateMana(regeneration);
    }
    public void RegerateMana(float _amoutAddedMana)
    {
        var regenerationMana = currentValue + _amoutAddedMana;
        currentValue = regenerationMana > maxValue ? maxValue : regenerationMana;
        ChangeCurrentValue?.Invoke(TypeName, currentValue, maxValue);
    }
}
