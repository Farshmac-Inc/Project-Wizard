using System;
using UnityEngine;

public abstract class Damageble : MonoBehaviour
{
    [NonSerialized] public GameObject Pooler;

    [SerializeField] private float health;
    [SerializeField]
    private Resistance[] resistances = new Resistance[3]
    {
        new Resistance(ManaType.Matter, 0),
        new Resistance(ManaType.Energy, 0),
        new Resistance(ManaType.Darkness, 0)
    };

    public void GetDamage(Damage[] _damages)
    {
        var newHealthValue = health - DamageCalculation(_damages);
        if (newHealthValue > 0) health = newHealthValue;
        else Die();
    }

    public abstract void Die();

    private float DamageCalculation(Damage[] _damages)
    {
        float pureDamage = 0;
        for (int i = 0; i < _damages.Length; i++)
        {
            for (int y = 0; y < resistances.Length; y++)
            {
                if (_damages[i].DamageType == resistances[y].ResistanceType)
                {
                    pureDamage += _damages[i].Value * (1 - resistances[y].Value);

                }
            }
        }
        Debug.Log($"{gameObject.name} получил {pureDamage} чистого урона.");
        return pureDamage;
    }
}
