using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MovementScript
{
    public Transform canon;
    float firerate;
    public GameObject bulletprefab;
    public Animator animator;
    public AudioSource Audio;
    public int health;
    public AudioClip destroyenemysound;
    Rigidbody2D rb2d;
    float horizontalvalue, verticalvalue;

    public static EnemyMovement instance;

    private void Awake()
    {
        instance = this;
    }

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
            BulletBehaviour.instance.deducthealth();
            if (health <= 100)
            {
                animator.SetTrigger("isDestroy");
                Destroy(gameObject, 0.3f);
                Audio.PlayOneShot(destroyenemysound);
                ScoreManager.instance.IncreaseScore(health);
                ScoreManager.instance.decreaseenemycount();
            }
        }

    } 
    void FixedUpdate()
    {
        if (verticalvalue != 0 && isMoving == false) StartCoroutine(MoveVertical(verticalvalue, rb2d));
        else if (horizontalvalue != 0 && isMoving == false) StartCoroutine(MoveHorizontal(horizontalvalue, rb2d));
    }
   
}