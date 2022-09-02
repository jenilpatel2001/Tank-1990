using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour
{
    
    public GameObject[] spawners;
    //game object
    public GameObject spawningobj;
    private int enemycount;
    public int spawnenemycount;
    //timer to spawn
    [SerializeField] private float timer;


    // Start is called before the first frame update
    void Start()
    {
        enemycount = 0;
        StartCoroutine(spawnenemytimegap());
    }

    void spawnenenemy()
    {
        Instantiate(spawningobj, spawners[Random.Range(0, spawners.Length)].transform.position, spawners[Random.Range(0, spawners.Length)].transform.rotation);
    }

    //co routine for spawn limited enemy
    IEnumerator spawnenemytimegap()
    {
        yield return new WaitForSeconds(timer);
        if (enemycount <= spawnenemycount)
        {
            spawnenenemy();
            enemycount++;
            StartCoroutine(spawnenemytimegap());
        }
    }

}
