using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void onPressed()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
//