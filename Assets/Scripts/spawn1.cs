using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn1 : MonoBehaviour
{
    GameObject[] tanks;
    GameObject tank;
    [SerializeField]
    GameObject smalltank,bigtank,fasttank,heavytank;


    private void Start()
    {
        tanks = new GameObject[4] { smalltank, bigtank, fasttank, heavytank };
    }

    public void startspawning()
    {

        tank = Instantiate(tanks[Random.Range(0, tanks.Length)], transform.position, transform.rotation);
        if (Random.value <= 0.5)
        {
          
            tank.GetComponent<BonusTank>().MakeBonusTank();
        }


    }

    //spawn new tank
    public void spawnnewtank()
    {
        if (tank != null) tank.SetActive(true);
    }
   
}
