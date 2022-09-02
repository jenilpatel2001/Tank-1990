using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour
{
    //[SerializeField] private GameObject spawnobject;
    ////start co-routine
    //IEnumerator enemyspawnroutine()
    //{
    //    Vector2 spawnpos = Vector2.zero;

    //    yield return new WaitForSeconds(2f);
    //    spawnpos.x = Random.Range(-9f, -9f);
    //    spawnpos.y = 5f;
    //    Instantiate(spawnobject, spawnpos, Quaternion.identity);
    //}
    //private void Start()
    //{
    //    StartCoroutine(enemyspawnroutine());
    //}


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
