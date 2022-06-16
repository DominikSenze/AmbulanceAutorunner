using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private bool powerUpActive;
    private float powerUpLengthCounter;

    private PlayerControl thePlayerControl;

    public AudioSource powerUpSound;
    public AudioSource powerUpFade;

    // Start is called before the first frame update
    void Start()
    {
        thePlayerControl = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpActive)
        {
            powerUpLengthCounter -= Time.deltaTime;

            thePlayerControl.hasPowerUp = true;


            if (powerUpLengthCounter <= 0)
            {
                thePlayerControl.hasPowerUp = false;

                powerUpActive = false;

                powerUpFade.Play();
            }
        }


    }


    public void ActivatePowerUp(float duration)
    {
        powerUpLengthCounter = duration;

        powerUpActive = true;

        powerUpSound.Play();
    }

}
