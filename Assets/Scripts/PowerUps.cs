using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public float powerUpLength;

    private PowerUpManager thePowerUpManager;

    // Start is called before the first frame update
    void Start()
    {
        thePowerUpManager = FindObjectOfType<PowerUpManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            thePowerUpManager.ActivatePowerUp(powerUpLength);
        }
        gameObject.SetActive(false);
    }
}
