using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Targetscript : MonoBehaviour
{
    public GameObject overscreen;
    public GameObject passedscreen;
    public TextMeshProUGUI finalscore;
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemybullet"))
        {
            Time.timeScale = 0;
            overscreen.SetActive(true);
            
        }else if (collision.gameObject.CompareTag("bullet"))
        {
            Time.timeScale = 0;
            overscreen.SetActive(true);
            
        }
    }
    private void Start()
    {
        overscreen.SetActive(false);
    }

    private void Update()
    {
        //  when enemycount board reach at 0 update levelcompletescreen active
        if(ScoreManager.instance.count == 0)
        {
           passedscreen.SetActive(true);   
               
        }
    }

    //set time 0
    public void pause()
    {
        Time.timeScale = 0;
    }
    //set time normal
    public void unpause()
    {
        Time.timeScale = 1;
    }
    //return to the home scene
    public void returntohome()
    {
        SceneManager.LoadScene("Home Screen");
    }
    //restart current scene
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        
    }
    //load next scene
    public void nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        
    }
    //quit the game
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
