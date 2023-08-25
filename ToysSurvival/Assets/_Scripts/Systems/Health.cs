using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    public  BaseStat stat;
    public UnityEvent OnDead;
    private void Start()
    {
        SetData();
    }

    public void SetData()
    {
        stat.currentHP = stat.maxHP;
    }

    public void TakeDamage(int damage)
    {
        stat.currentHP = Mathf.Clamp(stat.currentHP - damage, 0, stat.maxHP);

        if (stat.currentHP <= 0 )
        {
            OnDead.Invoke();
            GameAudio.instance.PlaySfx(stat,"Die");
            GameSpawn.instance.pool.Release(gameObject);
            GameManeger.Instance.save.Score++;
            GameManeger.Instance.save.UpdateTime();
            GameManeger.Instance.save.isTopKill();
        }
        else
        {
            GameAudio.instance.PlaySfx(stat, "Hurt");
        }
    }
}
