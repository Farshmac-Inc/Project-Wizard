using System;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : SkillObjectTemplate
{
    public float ExplosionRadius = 4.0f;
    public LayerMask MobLayer;

    public override void InternalService()
    {
    }

    public override void Move()
    {
        if (setActive)
        {
            transform.position += throwDirection * throwingObjectSpeedMovement * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision _collision)
    {
        Collider[] _hitMobs = Physics.OverlapSphere(_collision.contacts[0].point, ExplosionRadius, MobLayer);
        Pooler.GetComponent<SkillObjectPooler>().ObjectReturnPool(gameObject);
        if (_hitMobs.Length > 0)
        {
            List<Collider> _fixedHitMobs = new List<Collider>();
            foreach (var _hitMob in _hitMobs)
            {
                if (!_fixedHitMobs.Find(hit => hit.gameObject == _hitMob.gameObject))
                {
                    _fixedHitMobs.Add(_hitMob);
                    _hitMob.GetComponent<Damageble>().GetDamage(damage);
                }

            }
        }
        setActive = false;
    }
}

