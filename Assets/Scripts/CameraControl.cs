using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public PlayerControl thePlayer;
    private Vector3 playerPosition;
    private float moveDistance;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerControl>();
        playerPosition = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveDistance = thePlayer.transform.position.x - playerPosition.x;

        transform.position = new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z);
        
        playerPosition = thePlayer.transform.position;
    }
}
