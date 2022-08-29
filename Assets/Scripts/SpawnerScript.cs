using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] spawners;
    //game object
    public GameObject spawningobj;
    public float enemycount;
    //timer to spawn
    [SerializeField] private float timer;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnenemytimegap());
        //spawners = new GameObject[3];
        for (int i = 0; i < 6; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
    }
    
    
    void spawnenenemy()
    {
        Instantiate(spawningobj, spawners[Random.Range(0, spawners.Length)].transform.position, spawners[Random.Range(0, spawners.Length)].transform.rotation);
    }
    //co routine
    IEnumerator spawnenemytimegap()
    {
        yield return new WaitForSeconds(timer);
        enemycount = 0;
        if (enemycount < 6)
        {
            spawnenenemy();
            enemycount++;
            StartCoroutine(spawnenemytimegap());
        }
    }

}
