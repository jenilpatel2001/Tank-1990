using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
   public void loadlevel1()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }
    public void loadlevel2()
    {
        SceneManager.LoadScene("Level 2");
        Time.timeScale = 1;
    }
    public void loadlevel3()
    {
        SceneManager.LoadScene("Level 3");
        Time.timeScale = 1;
    }
    public void loadlevel4()
    {
        SceneManager.LoadScene("Level 4");
        Time.timeScale = 1;
    }
    public void loadlevel5()
    {
        SceneManager.LoadScene("Level 5");
        Time.timeScale = 1;
    }
    //quit the game
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
