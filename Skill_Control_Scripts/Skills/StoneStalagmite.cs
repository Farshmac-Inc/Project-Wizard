using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneStalagmite : SkillObjectTemplate
{
    public float DamageRadius = 4.0f;
    public LayerMask MobLayer;

    private Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public override void InternalService()
    {
        if (animator == null) animator = GetComponentInChildren<Animator>();
        animator.SetBool(0, true);
        DamageAround();
    }

    public override IEnumerator TimeToDeathCounter()
    {
        yield return new WaitForSeconds(LifeTime);
        setActive = false;
        animator.SetBool(0, false);

        yield return new WaitForSeconds(3.0f);
        Pooler.GetComponent<SkillObjectPooler>().ObjectReturnPool(gameObject);
    }

    public override void Move()
    {
    }

    private void DamageAround()
    {
        Vector3 _pos = gameObject.transform.position;
        Collider[] _hitMobs = Physics.OverlapCapsule(_pos, _pos, DamageRadius, MobLayer);
        Debug.Log(_hitMobs.Length);
        if (_hitMobs.Length > 0)
        {
            List<Collider> fixedHitMobs = new List<Collider>();
            foreach (var hitMob in _hitMobs)
            {
                if (!fixedHitMobs.Find(hit => hit.gameObject == hitMob.gameObject))
                {
                    fixedHitMobs.Add(hitMob);
                    hitMob.GetComponent<Damageble>().GetDamage(damage);
                }

            }
        }
        setActive = false;
    }
}

