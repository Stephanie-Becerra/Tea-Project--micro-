using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDayManger : MonoBehaviour
{
    private void Start()
    {
        endCanvas.enabled = false;    
    }

    [SerializeField] NPCScript theNPC;
    [SerializeField] Canvas endCanvas;

    //meant to be called when its offically the end of the day
    public void theEnd()
    {
        if (theNPC.isEndDay()) 
        {
            endCanvas.enabled = true;
        }
    }
    // meant to be called by the button on the end canvas. it should be 
    public void toStart() 
    {
        SceneManager.LoadScene("StartMenuScene");
    }
}
