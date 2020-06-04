using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SmallAlurtingRediusScript : PassiveAbility
{
    public float divider;
    public GameObject player;
    public AudioSource bossFootsteps;

    public override void Start()
    {
        base.Start();
        player.GetComponent<PlayerMovementScript>().radias[0] *= divider;
        player.GetComponent<PlayerMovementScript>().radias[1] *= divider;
        player.GetComponent<PlayerMovementScript>().radias[2] *= divider;
        player.GetComponent<PlayerMovementScript>().radias[3] *= divider;
        bossFootsteps.volume = 0.005f;
    }

    void Update()
    {

    }

}
