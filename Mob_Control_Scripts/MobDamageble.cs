using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobTemplate))]
public class MobDamageble : Damageble
{
    private MobTemplate template;

    private void Start()
    {
        template = GetComponent<MobTemplate>();
    }
    public override void Die() => template.Die(Pooler);    
}
