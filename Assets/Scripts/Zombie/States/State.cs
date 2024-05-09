using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State : MonoBehaviour
{
    public bool isComplete { get; protected set; }
    protected float startTime;
    public float time => Time.time - startTime;

    public Animator anim;
    protected bool walk;
    protected bool run;
    protected bool idle;
    protected bool attack;
    public NavMeshAgent navMesh;
    public virtual void Enter()
    {
        
    }

    public virtual void Do()
    {

    }

    public virtual void FixedDo()
    {

    }

    public virtual void Exit()
    {

    }

    
}
