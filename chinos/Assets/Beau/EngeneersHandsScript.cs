using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngeneersHandsScript : PassiveAbility
{
    public GameObject[] objectsWithTimer;
    public GameObject player;
    public float divider;
    public float multiplier;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        objectsWithTimer[0].GetComponent<GeneratorScript>().waitingTime *= multiplier;
        objectsWithTimer[1].GetComponent<GeneratorScript>().waitingTime *= multiplier;
        objectsWithTimer[2].GetComponent<GeneratorScript>().waitingTime *= multiplier;
        player.GetComponent<PlayerMovementScript>().fbspeed *= divider;
        player.GetComponent<PlayerMovementScript>().lrspeed *= divider;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
