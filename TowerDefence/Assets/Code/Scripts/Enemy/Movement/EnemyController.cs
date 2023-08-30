using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float attackRange;
    public float attackDamage;
    public float attackCooldown;
    public ThirdPersonCharacter character;

    private float _lastAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        _lastAttackTime = -attackCooldown; // Start with a negative value to allow the first attack immediately
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance > attackRange)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.SetDestination(transform.position);

            // Check if enough time has passed since the last attack
            if (Time.time - _lastAttackTime >= attackCooldown)
            {
                TrolleyHealth playerHealth = player.GetComponent<TrolleyHealth>();

                if (playerHealth != null)
                {
                    playerHealth.InflictDamage(attackDamage);
                    _lastAttackTime = Time.time; // Record the time of this attack
                }
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }
}
