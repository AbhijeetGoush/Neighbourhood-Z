using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    public GameObject zombie;
    ZombieHealth zombieHealth;

    private void Start()
    {
        zombieHealth = zombie.GetComponent<ZombieHealth>();
    }
    public override void Enter()
    {
        anim.SetBool("Attack", true);
    }

    public override void Do()
    {
        navMesh.speed = 0;

        if (zombieHealth.health <= 0)
        {
            isComplete = true;
        }

        if (walk == true || run == true || idle == true)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {
        
    }
}
