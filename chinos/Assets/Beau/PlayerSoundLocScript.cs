using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundLocScript : MonoBehaviour
{
    public int addTimeToTimer;
    public float timer;

    GameObject bossGameobject;
    public GameObject alertingObj;

    bool minusVolume;

    private void Start()
    {
        bossGameobject = GameObject.Find("Boss");
    }

    private void Update()
    {
        Timer();

        if (minusVolume == true)
        {
            bossGameobject.GetComponent<BossMovement>().followingMusic.volume -= .3f * Time.deltaTime;

            if (bossGameobject.GetComponent<BossMovement>().followingMusic.volume == 0)
            {
                minusVolume = false;
                bossGameobject.GetComponent<BossMovement>().followingMusic.Stop();
                bossGameobject.GetComponent<BossMovement>().followingMusic.volume = 0.3f;
            }
        }
    }

    public void Timer()
    {
        if (timer >= 0.00000000000000001)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= -0.0000001)
        {
            timer = 0;
                bossGameobject.GetComponent<BossMovement>().bossAgent.speed = bossGameobject.GetComponent<BossMovement>().bossSpeed;
                bossGameobject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                bossGameobject.GetComponent<BossMovement>().hasRunned1 = false;
                bossGameobject.GetComponent<BossMovement>().settingPlayerAsLocBool = false;
                bossGameobject.GetComponent<BossMovement>().bossAgent.SetDestination(bossGameobject.GetComponent<BossMovement>().newLocation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boss")
        {
            Vector3 desiredLocation = bossGameobject.GetComponent<BossMovement>().playerSoundLoc.transform.position;
            if (gameObject.transform.position == desiredLocation)
            {
                bossGameobject.GetComponent<BossMovement>().bossAgent.speed = 0f;
                bossGameobject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                timer = addTimeToTimer;

                minusVolume = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Boss")
        {

        }
    }
}
