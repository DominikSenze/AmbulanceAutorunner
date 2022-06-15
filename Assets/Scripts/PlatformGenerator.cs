using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generatorPoint;
    private float platformWidth;

    //Variables for different distances of platforms
    private float platformDistance;
    public float platformDistanceMin;
    public float platformDistanceMax;

    //Variables for Selection of different Platform types
    private int platformSelector;
    private float[] platformWidths;

    //reference to the ObjectPooler-Script
    public ObjectPooler[] theObjectPools;

    //Variables for height difference
    private float minHeight;
    private float maxHeight;
    public Transform maxHeightPoint;
    public float maxHeightChange;
    private float heightChange;

    //variables for ending random platforms
    public int platformCounter;
    public int platformCounterEnd;
    public GameObject goalPlatform;

    //variables for spawning AidKids
    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold; //controlls the amount of spawned aidKits

    //variables for spawning enemys
    public float randomEnemyThreshold;
    public ObjectPooler enemyPool;

    //variables for spawning PowerUps
    public float powerUpHeight;
    public ObjectPooler powerUpPool;
    public float powerUpThreshold;


    // Start is called before the first frame update
    void Start()
    {
        platformWidths = new float[theObjectPools.Length];

        for(int i =0; i<theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        //platformCounter = 0;
        goalPlatform.SetActive(false);

        //Finding and assigning the script CoinGenerator
        theCoinGenerator = FindObjectOfType<CoinGenerator>();

    }

    // Update is called once per frame
    void Update()
    {
        //creation of new platforms at PlatformGeneratorPoint
        if (transform.position.x < generatorPoint.position.x && platformCounter < platformCounterEnd) 
        {
            platformDistance = Random.Range(platformDistanceMin, platformDistanceMax); //choosing a distance

            platformSelector = Random.Range(0, theObjectPools.Length); //choosing one of the platform types

            //choosing the platform height
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange); //change is current position + random maxHeightChange number
            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            //Spawning PowerUps
            if(Random.Range(0f,100f) < powerUpThreshold)
            {
                GameObject newPowerUp = powerUpPool.GetPooledObject();

                newPowerUp.transform.position = transform.position + new Vector3(platformDistance / 2f, powerUpHeight, 0f);
                newPowerUp.SetActive(true);
            }

            //positioning the PlatformGeneratorPoint
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] /2) + platformDistance, heightChange, transform.position.z);

            //creating new platform
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            //spawns and positions the AidKits
            if (Random.Range(0f,100f) < randomCoinThreshold)
            {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z)); //the float controlls hight of aidKits
            }

            //spawns and positions the Enemy
            if (Random.Range(0f, 100f) < randomEnemyThreshold && platformSelector > 1)
            {
                GameObject newEnemy = enemyPool.GetPooledObject();

                Vector3 enemyPosition = new Vector3(0f, 0.3f, 0f);

                newEnemy.transform.position = transform.position + enemyPosition;
                newEnemy.transform.rotation = transform.rotation;
                newEnemy.SetActive(true);
                
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] /2), transform.position.y, transform.position.z);

            platformCounter++;
        }
        //placing the endgoal
        else
        {
            goalPlatform.transform.position = transform.position;
            goalPlatform.transform.rotation = transform.rotation;
            goalPlatform.SetActive(true);
        }

        
    }
}
