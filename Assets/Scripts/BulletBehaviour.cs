using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BulletBehaviour : MonoBehaviour
{
    public static BulletBehaviour instance;
    public float bulletspeed = 2.5f;
    int playerdamage = 100;
     public Animator animator;

    private void Awake()
    {
        instance = this;
    }
    

    //Update is called once per frame
    void Update()
    {
        // bullet moves towards axis
        transform.Translate(Vector3.up * bulletspeed * Time.deltaTime);

    }

    public void deducthealth()
    {
        EnemyMovement.instance.health -= playerdamage;
    }
 
    //bullet destroy when collide with other tag expect player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            animator.SetTrigger("destroybullet");
            
            PlayerBehaviour.instance.bulletsound();
            
            
        }
        //if (!collision.gameObject.CompareTag("Player"))
        //{
        //    Destroy(gameObject);
        //    PlayerBehaviour.instance.bulletsound();


        //}
    }
}
  



