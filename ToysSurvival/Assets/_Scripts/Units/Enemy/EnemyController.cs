using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float attackRange = 1.5f;
    public float attackCooldown = 2.0f; 
    public int damage = 10; 

    private GameObject player;
    private NavMeshAgent agent;
    private float lastAttackTime;

    public ParticleSystem explode;
    public GameDamageTarget Dealdamge;
    private void OnEnable()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        lastAttackTime = -attackCooldown;
    }

    private void FixedUpdate()
    {
        if (player == null) return;
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackRange)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time; 
            }
        }
        else
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void AttackPlayer()
    {
        CreateExplosion(player.transform.position);
        Dealdamge.DamgeTarget(player.GetComponent<Collider>());
    }

    private void CreateExplosion(Vector3 position)
    {
        ParticleSystem explosion = Instantiate(explode, position, Quaternion.identity);
        explosion.Play();
        Destroy(explosion.gameObject, explosion.main.duration);
    }
}
