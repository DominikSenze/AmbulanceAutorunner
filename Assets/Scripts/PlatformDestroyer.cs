using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    private GameObject platformDestoyerPoint;

    // Start is called before the first frame update
    void Start()
    {
        platformDestoyerPoint = GameObject.Find("PlatformDestroyerPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < platformDestoyerPoint.transform.position.x)
        {
            //Destroy(gameObject);

            gameObject.SetActive(false);
        }
    }
}
