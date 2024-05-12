using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    public GameObject zombie;
    ZombieHealth zombieHealth;
    ZombieAI zombieAI;
    private void Start()
    {
        zombieHealth = zombie.GetComponent<ZombieHealth>();
        zombieAI = zombie.GetComponent<ZombieAI>();
    }
    public override void Enter()
    {
        anim.SetBool("Attack", true);
    }

    public override void Do()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", true);
        anim.SetBool("Idle", false);

        navMesh.speed = 0;

        if (zombieHealth.health <= 0)
        {
            isComplete = true;
        }

        if (walk == true || run == true || idle == true)
        {
            isComplete = true;
        }

        if (!zombieAI.playerInSight && !zombieAI.playerInAttackRange && zombieHealth.health > 0)
        {
            isComplete = true;
        }
        if(!zombieAI.playerInAttackRange)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {
        
    }
}
