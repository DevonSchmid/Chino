using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatheryFeet : Abilitys
{
    public GameObject player;
    public float multiplier;
    public float time, fbspeed, lrspeed;
    public bool hasRunned;

    public float bossSpeedMultiplier;
    public BossMovement bossScript;

    public override void Start()
    {
        base.Start();
        lrspeed = player.GetComponent<PlayerMovementScript>().lrspeed;
        fbspeed = player.GetComponent<PlayerMovementScript>().fbspeed;
        bossScript.bossSpeed *= bossSpeedMultiplier;
    }

    public override void EPressed()
    {
        base.EPressed();
        if(abilityImageCover.rectTransform.sizeDelta.y == 0 && hasRunned == false)
        {
            hasRunned = true;
            StartCoroutine(Timer());
        }
    }

    public IEnumerator Timer()
    {
        player.GetComponent<PlayerMovementScript>().lrspeed *= multiplier;
        player.GetComponent<PlayerMovementScript>().fbspeed *= multiplier;
        player.GetComponent<PlayerMovementScript>().movementFbSpeed *= multiplier;
        player.GetComponent<PlayerMovementScript>().movementLrSpeed *= multiplier;
        yield return new WaitForSeconds(time);
        player.GetComponent<PlayerMovementScript>().fbspeed = fbspeed;
        player.GetComponent<PlayerMovementScript>().lrspeed = lrspeed;
        player.GetComponent<PlayerMovementScript>().movementFbSpeed /= multiplier;
        player.GetComponent<PlayerMovementScript>().movementLrSpeed /= multiplier;
        abilityImageCover.rectTransform.sizeDelta = new Vector2(0, 100);
        hasRunned = false;
    }
}
