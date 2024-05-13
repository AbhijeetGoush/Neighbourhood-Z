using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    ZombieHealth zombieHealth;
    PlayerHealth playerHealth;
    public GameObject playerObj;
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

    [SerializeField] LayerMask playerLayer;
    [SerializeField] float sightRange, attackRange;
    public bool playerInSight, playerInAttackRange;

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
        
        playerObj = GameObject.FindWithTag("Player");
        playerHealth = playerObj.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        state.Do();

        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (zombieHealth.health <= 0)
        {
            state = deathState;
        }

        if (state.isComplete)
        {
            SelectState();
        }
        print(state);
        idleTimer -= Time.deltaTime;
        //print(idleTimer);

    }

    void SelectState()
    {
        if(!playerInSight &&  !playerInAttackRange)
        {
            if (idleTimer > 0 && zombieHealth.health > 0 && state != run)
            {
                state = idleState;
            }
            if (idleTimer <= 0f && zombieHealth.health > 0 && state != run)
            {
                state = walkState;
            }
        }
        if (playerInSight && !playerInAttackRange && zombieHealth.health > 0)
        {
            state = runState;
        }
        if (playerInSight && playerInAttackRange && zombieHealth.health > 0)
        {
            state = attackState;
        }
        if (zombieHealth.health <= 0)
        {
            state = deathState;
        }
        state.Enter();
    }

    public void DamagePlayer()
    {
        playerHealth.currentHealth -= 10;
    }
}
