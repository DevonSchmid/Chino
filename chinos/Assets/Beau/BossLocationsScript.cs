using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLocationsScript : MonoBehaviour
{
    public float timer;
    public int addTimeToTimer;

    GameObject bossGameobject;

     void Start()
    {
        bossGameobject = GameObject.Find("Boss");
    }

    private void Update()
    {
        Timer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boss")
        {
            Vector3 desiredLocation = bossGameobject.GetComponent<BossMovement>().newLocation;
            if(gameObject.transform.position == desiredLocation)
            {
                bossGameobject.GetComponent<BossMovement>().bossAgent.speed = 0f;
                bossGameobject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                timer = addTimeToTimer;
            }
        }
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
            bossGameobject.GetComponent<BossMovement>().bossAgent.speed = bossGameobject.GetComponent<BossMovement>().bossSpeed;
            bossGameobject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            bossGameobject.GetComponent<BossMovement>().RandomLocationNumberGenerator();
        }
    }
}
