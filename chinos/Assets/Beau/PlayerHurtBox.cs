using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerHurtBox : MonoBehaviour
{
    public GameObject playerCam, bossFace;
    GameObject stunAbilityObj, bossGameobject;

    public AudioSource bossScareSound, defeatSound;

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
            bossGameobject.GetComponent<BossMovement>().bossAgent.speed = 0f;
            bossGameobject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            playerCam.transform.LookAt(bossFace.transform);

            if (stunAbilityObj == true)
            {
                stunAbilityObj.GetComponent<StunAbility>().AddTimeToTimer();
            }
            else
            {
                PlayerDied();
            }
        }
    }

    public void PlayerDied()
    {
        print("PlayerDead");
    }
}
