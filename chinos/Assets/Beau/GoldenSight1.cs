using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GoldenSight1 : Abilitys
{
    public GameObject[] objects, activeCheck;
    public GameObject player;
    public GameObject closestObject;
    public float time;

    public AudioSource alertingSound;
    public GameObject bossObj, playerSoundLoc, playerObj;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void EPressed()
    {
        base.EPressed();
        if (abilityImageCover.rectTransform.sizeDelta.y == 0)
        {
            GetClosestObject();
            MakeNoise();
            StartCoroutine(Timer());
        }
    }

    void MakeNoise()
    {
        alertingSound.Play();
        playerSoundLoc.transform.position = new Vector3(playerObj.transform.position.x, playerSoundLoc.transform.position.y, playerObj.transform.position.z);
        bossObj.GetComponent<BossMovement>().newLocation = playerSoundLoc.transform.position;
        bossObj.GetComponent<BossMovement>().bossAgent.SetDestination(playerSoundLoc.transform.position);
    }

    public GameObject GetClosestObject()
    {
        float closest = 999999999999999;
        closestObject = null;
        for (int i = 0; i < objects.Length; i++) 
        {
            float dist = Vector3.Distance(objects[i].transform.position, player.transform.position);
            if (dist < closest)
            {
                if (activeCheck[i].activeSelf == true)
                { 
                    closest = dist;
                    closestObject = objects[i];
                }
            }
        }
        return closestObject;
    }
    public IEnumerator Timer()
    {
        closestObject.SetActive(true);
        yield return new WaitForSeconds(time);
        closestObject.SetActive(false);
        abilityImageCover.rectTransform.sizeDelta = new Vector2(0, 100);

    }
}
