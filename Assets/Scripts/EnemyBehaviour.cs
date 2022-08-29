//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

////enemy ai random grid movement-----------------------------------------------
//public class EnemyBehaviour : MonoBehaviour
//{

//    public float speed;
//    private Rigidbody2D rb;

//    private float currenttime = 0;
//    float x;
//    float y;
//    public GameObject Bullet;
//    Vector2 randomdir;


//    public Transform canon;
//    float bulletfiregap;

//    bool isMoving;

//    float horizontalvalue;
//    float verticalvalue;
//    enum Direction { Up, Down, Left, Right };
//    Direction[] directions = { Direction.Up, Direction.Down, Direction.Left, Direction.Right };




//    public void randomdirection()
//    {
//        Direction selection = directions[Random.Range(0, 5)];
//        if (selection == Direction.Up)
//        {
//            verticalvalue = 1;
//            horizontalvalue = 0;
//        }
//        if (selection == Direction.Up)
//        {
//            verticalvalue = -1;
//            horizontalvalue = 0;
//        }
//        if (selection == Direction.Up)
//        {
//            verticalvalue = 0;
//            horizontalvalue = 1;
//        }
//        if (selection == Direction.Up)
//        {
//            verticalvalue = 0;
//            horizontalvalue = -1;
//        }

//    }
//    public void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        randomdirection();
//        isMoving = true;
//    }

//    private void Update()
//    {
//        bulletfiregap -= Time.deltaTime;

//        if (bulletfiregap < 0)
//        {
//            Instantiate(Bullet, canon.position, transform.rotation);
//            bulletfiregap = 3;
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        randomdirection();

//    }

    

//    public void FixedUpdate()
//    {
        

//        if (verticalvalue != 0 && isMoving == false) StartCoroutine(MoveVertical(verticalvalue, rb));
//        else if (horizontalvalue != 0 && isMoving == false) StartCoroutine(MoveHorizontal(horizontalvalue, rb));
        




//        /*currenttime += Time.fixedDeltaTime;
//        if (currenttime > 2)
//        {
//            x = Random.Range(-1f, 1f);
//            y = Random.Range(-1f, 1f);
//            randomdir = new Vector3( x, y);


//               // rb.AddForce(randomdir);


//                // face towards movement
//                if (randomdir != Vector2.zero)
//                {
//                    transform.rotation = Quaternion.LookRotation(Vector3.forward, randomdir);
//                }


//                currenttime = 0;
//        }


//        rb.velocity = new Vector2(x, y) * speed;

//    }*/

//    }
//}
