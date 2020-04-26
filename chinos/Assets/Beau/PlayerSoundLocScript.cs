using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundLocScript : MonoBehaviour
{
    public int addTimeToTimer;
    public float timer;

    GameObject bossGameobject;

    bool ifInCol;

    private void Start()
    {
        bossGameobject = GameObject.Find("Boss");
    }

    private void Update()
    {
        Timer();
    }

    public void Timer()
    {
        if (timer >= 0.000000001)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= -0.0000001)
        {
            timer = 0;
            if (ifInCol == true)
            {
                bossGameobject.GetComponent<BossMovement>().hasRunned1 = false;
                bossGameobject.GetComponent<BossMovement>().settingPlayerAsLocBool = false;
                bossGameobject.GetComponent<BossMovement>().bossAgent.SetDestination(bossGameobject.GetComponent<BossMovement>().newLocation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boss")
        {
            Vector3 desiredLocation = bossGameobject.GetComponent<BossMovement>().playerSoundLoc.transform.position;
            if (gameObject.transform.position == desiredLocation)
            {
                ifInCol = true;
                timer = addTimeToTimer;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Boss")
        {
            ifInCol = false;
        }
    }
}
