using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkState : State
{
    public GameObject destination;

    int xPos;
    int zPos;
    public int randomLowerX;
    public int randomHigherX;
    public int randomLowerZ;
    public int randomHigherZ;

    ZombieAI zombieAI;
    ZombieHealth zombieHealth;
    public GameObject zombieObj;

    public Vector3 destPoint;

    bool walkPointSet;
    [SerializeField] float walkRange;

    private void Start()
    {
        zombieAI = zombieObj.GetComponent<ZombieAI>();
        zombieHealth = zombieObj.GetComponent<ZombieHealth>();
    }

    public override void Enter()
    {
        anim.SetBool("Walk", true);
        anim.SetBool("Idle", false);
    }

    public override void Do()
    {
        navMesh.speed = 1;

        if (zombieHealth.health <= 0)
        {
            isComplete = true;
        }

        if (!walkPointSet)
        {
            SearchForDest();
        }
        if (walkPointSet)
        {
            navMesh.SetDestination(destPoint);
        }
        if(Vector3.Distance(transform.position, destPoint) < 10)
        {
            walkPointSet = false;
            zombieAI.idleTimer = 4f;
            isComplete = true;
            idle = true;
            walk = false;
        }

        if(idle == true || run == true || attack == true)
        {
            isComplete = true;
        }
    }

    public override void Exit()
    {

    }

    void SearchForDest()
    {
        float z = Random.Range(-walkRange, walkRange);
        float x = Random.Range(-walkRange, walkRange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        walkPointSet = true;
    }
}
