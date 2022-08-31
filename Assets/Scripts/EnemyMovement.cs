using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MovementScript
{
    public Transform canon;
    float firerate;
    public GameObject bulletprefab;
    public Animator animator;
    public AudioSource audio;
    public AudioClip destroyenemysound;
    
    Rigidbody2D rb2d;
    float horizontalvalue, verticalvalue;

    

    enum Direction { Up, Down, Left, Right };
    Direction[] direction = { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        RandomDirection();
    }
    public void RandomDirection()
    {
        Direction selection = direction[Random.Range(0, 4)];
        if (selection == Direction.Up)
        {
            verticalvalue = 1;
            horizontalvalue = 0;
        }
        if (selection == Direction.Down)
        {
            verticalvalue = -1;
            horizontalvalue = 0;
        }
        if (selection == Direction.Right)
        {
            verticalvalue = 0;
            horizontalvalue = 1;
        }
        if (selection == Direction.Left)
        {
            verticalvalue = 0;
            horizontalvalue = -1;
        }
    }
    private void Update()
    {
        firerate -= Time.deltaTime;

        if (firerate < 0)
        {
            Instantiate(bulletprefab, canon.position, transform.rotation);
            firerate = 2;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        RandomDirection();
        if (collision.gameObject.CompareTag("bullet"))
        {

            animator.SetTrigger("isDestroy");
            audio.PlayOneShot(destroyenemysound);
            Destroy(gameObject, 0.3f);
            ScoreManager.instance.IncreaseScore(100);
            ScoreManager.instance.decreaseenemycount();

        }

    }

        
    
    void FixedUpdate()
    {
        if (verticalvalue != 0 && isMoving == false) StartCoroutine(MoveVertical(verticalvalue, rb2d));
        else if (horizontalvalue != 0 && isMoving == false) StartCoroutine(MoveHorizontal(horizontalvalue, rb2d));
    }
    public void death()
    {
        
    }
    
}