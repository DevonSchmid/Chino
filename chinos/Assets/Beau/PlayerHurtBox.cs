using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerHurtBox : MonoBehaviour
{
    public GameObject playerCam, bossFace;
    GameObject stunAbilityObj, bossGameobject;

    public AudioSource bossScareSound, defeatSound;

    bool lookAtBoss;
    private void Start()
    {
        bossGameobject = GameObject.Find("Boss");
        stunAbilityObj = GameObject.Find("StunAbility");
    }

    private void Update()
    {
        if(lookAtBoss == true)
        {
            playerCam.transform.LookAt(bossFace.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boss")
        {
            GetComponentInParent<PlayerMovementScript>().ableToMove = false;
            bossGameobject.GetComponent<BossMovement>().bossAgent.speed = 0f;
            bossGameobject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

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
        lookAtBossTimer();
    }

    IEnumerator lookAtBossTimer()
    {
        bossScareSound.Play();
        lookAtBoss = true;
        yield return new WaitForSeconds(2.6f);
        lookAtBoss = false;
    }
}
