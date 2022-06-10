using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generatorPoint;
    public float platformDistance;
    private float platformWidth;


    // Start is called before the first frame update
    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x; //gives us the length of platform
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generatorPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + platformDistance, transform.position.y, transform.position.z);

            Instantiate(thePlatform, transform.position, transform.rotation);
        }
    }
}
