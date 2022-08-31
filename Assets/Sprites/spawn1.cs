using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn1 : MonoBehaviour
{
    GameObject[] tanks;
    GameObject tank;
    [SerializeField]
    bool isPlayer;
    [SerializeField]
    GameObject smalltank, bigtank, fasttank, armoredtank;

    //identify player spawner
    private void Start()
    {
        if (isPlayer)
        {
            tanks = new GameObject[1] { smalltank };
        }
        else
        {
            tanks = new GameObject[4] { smalltank, bigtank, fasttank, armoredtank };
        }
    }

    //startspawning...
    public void startspawning()
    {
        tank = Instantiate(tanks[Random.Range(0, tanks.Length)], transform.position, transform.rotation);
    }
    //spawn new tank
    public void spawnnewtank()
    {
        if (tank != null) tank.SetActive(true);
    }
}
