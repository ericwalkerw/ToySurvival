using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDamageTarget : MonoBehaviour
{
    public BaseStat stat;
    public void DamgeTarget(Collider other)
    {
        var Target = other.GetComponent<IDamageable>();

        if (Target != null)
        {
            Target.TakeDamage(stat.damage);
        }
    }
}
