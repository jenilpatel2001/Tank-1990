using System.Collections;
using System.Collections.Generic;
using SimpleInputNamespace;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerBehaviour : MonoBehaviour
{
     float speed = 2;
    //public LayerMask stopmove;
  

   
    Rigidbody2D rb;
    [SerializeField] Transform canon;
    [SerializeField] GameObject BulletPrefab;

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    private float inputHorizontal;
    private float inputVertical;

    public GameObject overscreen;
    public TextMeshProUGUI finalscore;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        overscreen.gameObject.SetActive(false);
    }

  


    //ui movements by event trigger------------------


    // Update is called once per frame
    void Update()
    {

        //dpad controls
        inputHorizontal = SimpleInput.GetAxis(horizontalAxis);
        inputVertical = SimpleInput.GetAxis(verticalAxis);

        
        //Flip the player towards Direction------------------------------------------------------------------------------
        if (inputHorizontal > 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0f, 0f, -90f);

        }
        if (inputHorizontal < 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0f, 0f, 90f);
        }
        if (inputVertical > 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (inputVertical < 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }


        Vector3 movedirection = new Vector3(inputHorizontal, 0, 0);
        Vector3 movedirection2 = new Vector3(0, inputVertical, 0);

        if (movedirection != Vector3.zero)
        {
            transform.Translate(movedirection * speed * Time.deltaTime, Space.World);
        }
        else if (movedirection2 != Vector3.zero)
        {
            transform.Translate(movedirection2 * speed * Time.deltaTime, Space.World);
        }
       
    }

    


    public void onfire()
    {
       Instantiate(BulletPrefab, canon.position, transform.rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemybullet"))
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            overscreen.gameObject.SetActive(true);
            ScoreManager.instance.decreaselife();


        }
    }

}
