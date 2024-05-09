using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunState : State
{
    public override void Enter()
    {
        anim.SetBool("Run", true);
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", false);
    }

    public override void Do()
    {
        navMesh.speed = 6;

        if (idle == true || walk == true || attack == true)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {

    }
}
