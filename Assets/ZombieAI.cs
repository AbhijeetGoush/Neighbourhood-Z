using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public State idleState;
    public State walkState;
    public State runState;
    public State attackState;

    public bool idle;
    public bool walk;
    public bool run;
    public bool attack;

    public NavMeshAgent navMesh;
    public Animator anim;

    public float idleTimer = 4f;

    State state;
    // Start is called before the first frame update
    void Start()
    {
        state = idleState;

        idleState.anim = anim;
        runState.anim = anim;
        walkState.anim = anim;
        attackState.anim = anim;

        idleState.navMesh = navMesh;
        runState.navMesh = navMesh;
        walkState.navMesh = navMesh;
        attackState.navMesh = navMesh;

        anim = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();

        state.anim = anim;
    }

    // Update is called once per frame
    void Update()
    {
        state.Do();
        
        if(state.isComplete)
        {
            SelectState();
        }
        //print(state);
        idleTimer -= Time.deltaTime;
        print(idleTimer);

    }

    void SelectState()
    {
        if (idleTimer > 0)
        {
            state = idleState;
        }
        if (idleTimer <= 0f)
        {
            state = walkState;
        }
        if (run)
        {
            state = runState;
        }
        if (attack)
        {
            state = attackState;
        }
        state.Enter();
    }

}
