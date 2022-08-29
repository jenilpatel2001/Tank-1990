using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image topimage;
    [SerializeField] Image bottomimage;
    [SerializeField] Image blackimage;
    [SerializeField] TextMeshProUGUI levelnumber;
    
    private void Start()
    {
       
        StartCoroutine(RevealStageNumber());
        
    }
    IEnumerator RevealStageNumber()
    {
        while (blackimage.rectTransform.localScale.y > 0)
        {
            blackimage.rectTransform.localScale = new Vector3(blackimage.rectTransform.localScale.x,
                Mathf.Clamp(blackimage.rectTransform.localScale.y - Time.deltaTime, 0, 1),
                blackimage.rectTransform.localScale.z);

            yield return null;
            
        }
       
    }
    
}

