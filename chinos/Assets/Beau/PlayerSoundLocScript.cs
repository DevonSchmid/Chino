using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundLocScript : MonoBehaviour
{
    public int addTimeToTimer;
    public float timer;

    GameObject bossGameobject;

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
            bossGameobject.GetComponent<BossMovement>().bossAgent.SetDestination(bossGameobject.GetComponent<BossMovement>().newLocation);
            print("doorgaan met lopen naar newloc");
            bossGameobject.GetComponent<BossMovement>().hasRunned = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boss")
        {
            Vector3 desiredLocation = bossGameobject.GetComponent<BossMovement>().playerSoundLoc.transform.position;
            if (gameObject.transform.position == desiredLocation)
            {
                timer = addTimeToTimer;
            }
        }
    }
}
