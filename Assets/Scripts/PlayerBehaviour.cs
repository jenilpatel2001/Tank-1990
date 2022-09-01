using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
   
    float speed = 2;
    public AudioSource audiosourse;
    public AudioClip audioclip;
    public static PlayerBehaviour instance;
    [SerializeField] Transform canon;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Animator anime;
    public AudioClip bulletdestroy;
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    private float inputHorizontal;
    private float inputVertical;
   
    public GameObject overscreen;

    private float timewhenallowednextshoot = 0f;
    private float firegap = 0.5f;


    private void Awake()
    {
        instance = this;
    }

    void Update()
    {

        //dbutton controls
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
    //enemy bullet destroy sound
    public void bulletsound()
    {
        audiosourse.PlayOneShot(bulletdestroy);
    }



    public void onfire()
    {
        if (timewhenallowednextshoot <= Time.time)
        {
            audiosourse.PlayOneShot(audioclip);
            Instantiate(BulletPrefab, canon.position, transform.rotation);
            timewhenallowednextshoot = Time.time + firegap;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemybullet"))
        {
                Time.timeScale = 0;
                anime.SetTrigger("dead");

                overscreen.gameObject.SetActive(true);
                ScoreManager.instance.decreaselife();
            }
           

        }
    }


