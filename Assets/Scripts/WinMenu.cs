using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();

    }

    public void QuitTheGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
