using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertScript : MonoBehaviour
{
    public bool inRange;
    public GameObject bossGameobject;

    public void Start()
    {
        bossGameobject = GameObject.Find("Boss");
    }
    private void Update()
    {
        if(inRange == true)
        {
            bossGameobject.GetComponent<BossMovement>().HearingPLayer();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boss")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Boss")
        {
            inRange = false;
        }
    }
}
