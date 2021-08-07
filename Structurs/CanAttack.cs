using System;
using UnityEngine;

[RequireComponent(typeof(Damageble))]
public class CanAttack : MonoBehaviour
{

    [NonSerialized] public GameObject Pooler;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject attackZone;
    [SerializeField]
    private Damage[] damages = new Damage[3]
    {
        new Damage(ManaType.Matter, 0),
        new Damage(ManaType.Energy, 0),
        new Damage(ManaType.Darkness, 0)
    };

    public void DealDamage(GameObject _damageableObject)
    {
        _damageableObject.GetComponent<Damageble>().GetDamage(damages);
        GetComponent<Damageble>().Die();
    }
    private void OnCollisionEnter(Collision _collision)
    {
        var layer = _collision.gameObject.layer;
        if ((enemyLayer.value & (1<<layer)) != 0)
        {
            DealDamage(_collision.gameObject);
        }
    }
}
