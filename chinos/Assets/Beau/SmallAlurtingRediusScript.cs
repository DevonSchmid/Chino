using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAlurtingRediusScript : PassiveAbility
{
    public float divider;
    public GameObject player;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        player.GetComponent<PlayerMovementScript>().radias[0] *= divider;
        player.GetComponent<PlayerMovementScript>().radias[1] *= divider;
        player.GetComponent<PlayerMovementScript>().radias[2] *= divider;
        player.GetComponent<PlayerMovementScript>().radias[3] *= divider;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
