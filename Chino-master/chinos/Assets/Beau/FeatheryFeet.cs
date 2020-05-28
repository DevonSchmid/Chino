using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatheryFeet : Abilitys
{
    public GameObject player;
    public float multiplier;
    public float time, fbspeed, lrspeed;
    public bool hasRunned;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        lrspeed = player.GetComponent<PlayerMovementScript>().lrspeed;
        fbspeed = player.GetComponent<PlayerMovementScript>().fbspeed;
    }

    public override void EPressed()
    {
        base.EPressed();
        if(abilityImageCover.rectTransform.sizeDelta.y == 0 && hasRunned == false)
        {
            print("test");
            hasRunned = true;
            StartCoroutine(Timer());
        }
    }

    public IEnumerator Timer()
    {
        player.GetComponent<PlayerMovementScript>().lrspeed *= multiplier;
        player.GetComponent<PlayerMovementScript>().fbspeed *= multiplier;
        yield return new WaitForSeconds(time);
        print("hoi");
        player.GetComponent<PlayerMovementScript>().fbspeed = fbspeed;
        player.GetComponent<PlayerMovementScript>().lrspeed = lrspeed;
        abilityImageCover.rectTransform.sizeDelta = new Vector2(0, 100);
        hasRunned = false;
    }
}
