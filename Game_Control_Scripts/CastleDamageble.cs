using UnityEngine;

class CastleDamageble : Damageble
{
    public override void Die()
    {
        Debug.Log("You Lose");
    }
}