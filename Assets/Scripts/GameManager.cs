using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //variables for reset of platforms & player after death
    public Transform platformGenerator;
    private Vector3 platformStartPoint;
    public PlayerControl thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    //variables for reference to other Scripts
    private ScoreManager theScoreManager;
    private PlatformGenerator thePlatformGenerator;
    public DeathMenu theDeathScreen;
  



    // Start is called before the first frame update
    void Start()
    {

        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //functions for deathmenu
    public void RestartGame()
    {
        Time.timeScale = 0; //freezing the screen
        
        thePlayer.gameObject.SetActive(false); //player becomes invisible when dying

        theDeathScreen.gameObject.SetActive(true); //activates The DeathMenu
        

        //StartCoroutine("RestartGameCo"); //Coroutine adds some time-delay before reseting the game
    }

    public void Reset()
    {
        Time.timeScale = 1; //unfreezing the screen

        theDeathScreen.gameObject.SetActive(false); //deactivates The DeathMenu

        platformList = FindObjectsOfType<PlatformDestroyer>(); //finding all existing platforms
        for (int i = 0; i < platformList.Length; i++) //all platforms will become invisible
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint; //reseting player
        platformGenerator.position = platformStartPoint; //reseting platforms
        thePlayer.gameObject.SetActive(true); //player becomes visible again after reset to beginning

        //reseting score
        theScoreManager.scoreCount = 0;

        //reseting end of random platforms and goal platform
        thePlatformGenerator.platformCounter = 0;
        thePlatformGenerator.goalPlatform.SetActive(false);
    }

    //reseting the game
    /*public IEnumerator RestartGameCo() 
    {
        theScoreManager.scoreIncrease = false; //stopping the score
        
        thePlayer.gameObject.SetActive(false); //player becomes invisible when dying
        yield return new WaitForSeconds(0.5f); //adding some time-delay

        platformList = FindObjectsOfType<PlatformDestroyer>(); //finding all existing platforms
        for(int i =0; i<platformList.Length; i++) //all platforms will become invisible
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint; //reseting player
        platformGenerator.position = platformStartPoint; //reseting platforms
        thePlayer.gameObject.SetActive(true); //player becomes visible again after reset to beginning

        //reseting score
        theScoreManager.scoreCount = 0; 
        theScoreManager.scoreIncrease = true;

        //reseting end of random platforms and goal platform
        thePlatformGenerator.platformCounter = 0; 
        thePlatformGenerator.goalPlatform.SetActive(false);
     
    }*/
}
