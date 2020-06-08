using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlsEarsScript : PassiveAbility
{
    public GameObject stepSounds, alertingRadius, player;
    public float newVolume, newDist, lrspeed, fbspeed, minusSpeed, maxfbSpeed, maxlrSpeed;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        stepSounds.GetComponent<AudioSource>().volume = newVolume;
        stepSounds.GetComponent<AudioSource>().maxDistance = newDist;
    }

    // Update is called once per frame
    void Update()
    {        

    }

    public void MinusSpeed()
    {
        if (player.GetComponent<PlayerMovementScript>().fbspeed >= maxfbSpeed && player.GetComponent<PlayerMovementScript>().lrspeed >= maxlrSpeed)
        {
            print("test");
            player.GetComponent<PlayerMovementScript>().fbspeed -= fbspeed;
            player.GetComponent<PlayerMovementScript>().lrspeed -= lrspeed;
            player.GetComponent<PlayerMovementScript>().movementFbSpeed -= minusSpeed;
            player.GetComponent<PlayerMovementScript>().movementLrSpeed -= minusSpeed;
        }
    }
}
