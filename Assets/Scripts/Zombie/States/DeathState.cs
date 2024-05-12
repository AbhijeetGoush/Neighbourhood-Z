using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    ZombieAI zombieAI;
    public GameObject zombieObj;
    BoxCollider boxCol;

    float destroyTimer = 5;
    private void Start()
    {
        zombieAI = zombieObj.GetComponent<ZombieAI>();
        boxCol = zombieObj.GetComponent<BoxCollider>();
    }
    public override void Enter()
    {
        attack = false;
        walk = false;
        idle = false;
        run = false;
        anim.SetBool("Death", true);
        anim.SetBool("Attack", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Run", false);
    }
    public override void Do()
    {
        navMesh.speed = 0;
        anim.SetBool("Death", true);
        anim.SetBool("Attack", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Run", false);

        Destroy(boxCol);

        destroyTimer -= Time.deltaTime;
        if(destroyTimer <= 0)
        {
            Destroy(zombieObj);
        }
    }

    
    public override void Exit()
    {

    }
}
