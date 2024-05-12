using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    ZombieAI zombieAI;
    ZombieHealth zombieHealth;
    public GameObject zombieObj;
    private void Start()
    {
        zombieAI = zombieObj.GetComponent<ZombieAI>();
        zombieHealth = zombieObj.GetComponent<ZombieHealth>();
    }

    public override void Enter()
    {
        anim.SetBool("Idle", true);
        anim.SetBool("Walk", false);
    }

    public override void Do()
    {
        navMesh.speed = 0;

        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Idle", true);

        if (zombieHealth.health <= 0)
        {
            isComplete = true;
        }

        if (zombieAI.idleTimer <= 0f)
        {
            walk = true;
            idle = false;

            isComplete = true;
        }

        if (zombieAI.playerInSight && !zombieAI.playerInAttackRange && zombieHealth.health > 0)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {
        
    }
}
