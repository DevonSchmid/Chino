using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefsSightScript : Abilitys
{
    public GameObject[] objects, activeCheck;
    public GameObject player;
    public GameObject closestObject;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void EPressed()
    {
        base.EPressed();
        GetClosestObject();
        closestObject.SetActive(true);
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
}
