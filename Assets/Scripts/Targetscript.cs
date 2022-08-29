using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        if(ScoreManager.instance.count == 0)
        {
            
            Time.timeScale = 0;
            passedscreen.SetActive(true);
           // ScoreManager.instance.scoreTxt = finalscore;
               
        }
    }


    public void pause()
    {
        Time.timeScale = 0;
    }
    public void unpause()
    {
        Time.timeScale = 1;
    }

    public void returntohome()
    {
        SceneManager.LoadScene("Home Screen");
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
}
