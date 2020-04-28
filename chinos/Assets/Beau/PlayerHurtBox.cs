using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{
    GameObject stunAbilityObj, bossGameobject;

    private void Start()
    {
        bossGameobject = GameObject.Find("Boss");
        stunAbilityObj = GameObject.Find("StunAbility");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boss")
        {
            GetComponentInParent<PlayerMovementScript>().ableToMove = false;
            bossGameobject.GetComponent<BossMovement>().bossAgent.speed = .5f;
            if (stunAbilityObj == true)
            {
                stunAbilityObj.GetComponent<StunAbility>().AddTimeToTimer();
            }
            else
            {
                //PlayerDied();
            }
        }
    }

    public void PlayerDied()
    {
        print("PlayerDead");
    }
}
