using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    int score;
    int life;
    public int count;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI lifetxt;
    public TextMeshProUGUI FINALSCORETXT;
    public TextMeshProUGUI enemycounttxt;
    
    private void Start()
    {
        score = 0;
        life = 1;
        
    }
    private void Awake()
    {
        instance = this;
    }

    public void IncreaseScore(int s)
    {
        score += s;
        scoreTxt.text = score.ToString();
        FINALSCORETXT.text = score.ToString();
       
    }
    
    public void decreaselife()
    {
        life -= 1;
        lifetxt.text = life.ToString();

        
    }
    public void decreaseenemycount()
    {
        count -= 1;
        enemycounttxt.text = count.ToString();
        
    }
}
