using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public static BulletBehaviour instance;
    float bulletspeed = 2.5f;
    PlayerBehaviour player;
    float horizontalspeed;
    float verticalspeed;
    int damage = 100;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // bullet moves towards axis
        transform.Translate(Vector3.up * bulletspeed* Time.deltaTime);
        
    }

    public void deducthealth(int d)
    {
        EnemyMovement.instance.health -= d;
    }
 
    //bullet destroy when collide with other tag expect player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerBehaviour.instance.bulletsound();
            
            
        }
    }
}
  



