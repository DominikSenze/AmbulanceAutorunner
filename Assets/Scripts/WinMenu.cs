using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();

    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
