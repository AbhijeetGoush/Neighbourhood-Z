using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombieObject;
    int xPos;
    int zPos;
    public int randomLowerX;
    public int randomHigherX;
    public int randomLowerZ;
    public int randomHigherZ;
    public int spawnTimer;
    bool spawnZombie;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ZombieSpawn());
    }

    IEnumerator ZombieSpawn()
    {
        spawnZombie = true;
        while(spawnZombie == true)
        {
            xPos = Random.Range(randomLowerX, randomHigherX);
            zPos = Random.Range(randomLowerZ, randomHigherZ);
            Instantiate(zombieObject, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
