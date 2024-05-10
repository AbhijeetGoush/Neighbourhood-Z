using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    ZombieHealth zombieHealth;
    public State idleState;
    public State walkState;
    public State runState;
    public State attackState;
    public State deathState;

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
        deathState.anim = anim;

        idleState.navMesh = navMesh;
        runState.navMesh = navMesh;
        walkState.navMesh = navMesh;
        attackState.navMesh = navMesh;
        deathState.navMesh = navMesh;

        anim = GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();

        state.anim = anim;

        zombieHealth = GetComponent<ZombieHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        state.Do();

        if (zombieHealth.health <= 0)
        {
            state = deathState;
        }

        if (state.isComplete)
        {
            SelectState();
        }
        //print(state);
        idleTimer -= Time.deltaTime;
        //print(idleTimer);

    }

    void SelectState()
    {
        if (idleTimer > 0 && zombieHealth.health > 0)
        {
            state = idleState;
        }
        if (idleTimer <= 0f && zombieHealth.health > 0)
        {
            state = walkState;
        }
        if (run && zombieHealth.health > 0)
        {
            state = runState;
        }
        if (attack && zombieHealth.health > 0)
        {
            state = attackState;
        }
        if(zombieHealth.health <= 0)
        {
            state = deathState;
        }
        state.Enter();
    }

}
