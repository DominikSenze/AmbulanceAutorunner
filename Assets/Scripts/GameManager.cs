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



    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo"); //Coroutine adds some time-delay before reseting the game
    }

    //reseting the game
    public IEnumerator RestartGameCo() 
    {
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
    }
}
