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


    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x; //gives us the length of platform

        platformWidths = new float[theObjectPools.Length];

        for(int i =0; i<theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generatorPoint.position.x) //creation of new platforms at PlatformGeneratorPoint
        {
            platformDistance = Random.Range(platformDistanceMin, platformDistanceMax); //choosing a distance

            platformSelector = Random.Range(0, theObjectPools.Length); //choosing one of the platform types

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] /2) + platformDistance, transform.position.y, transform.position.z);

            //creating new platform
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] /2), transform.position.y, transform.position.z);

        }
    }
}
