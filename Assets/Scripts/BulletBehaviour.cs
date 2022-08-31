using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    float bulletspeed = 2.5f;
    PlayerBehaviour player;
    float horizontalspeed;
    float verticalspeed;
    


    // Update is called once per frame
    void Update()
    {
        // bullet moves towards axis
        transform.Translate(Vector3.up * bulletspeed* Time.deltaTime);
        
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
  



