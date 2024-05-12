using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunState : State
{
    public GameObject zombie;
    GameObject playerObj;

    ZombieHealth zombieHealth;
    ZombieAI zombieAI;
    private void Start()
    {
        zombieHealth = zombie.GetComponent<ZombieHealth>();
        zombieAI = zombie.GetComponent<ZombieAI>();
        playerObj = GameObject.Find("PlayerFPS");
    }
    public override void Enter()
    {
        anim.SetBool("Run", true);
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Idle", false);
    }

    public override void Do()
    {
        navMesh.speed = 4;
        Chase();

        anim.SetBool("Run", true);
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Idle", false);
        if (zombieHealth.health <= 0)
        {
            isComplete = true;
        }

        if (zombieHealth.health <= 0)
        {
            isComplete = true;
        }

        if (idle == true || walk == true || attack == true)
        {
            isComplete = true;
        }
        
        if(!zombieAI.playerInSight && !zombieAI.playerInAttackRange && zombieHealth.health > 0)
        {
            isComplete = true;
        }
        if(zombieAI.playerInAttackRange)
        {
            isComplete = true;
        }
        
    }

    void Chase()
    {
        navMesh.SetDestination(playerObj.transform.position);
    }

    public override void Exit()
    {

    }
}
