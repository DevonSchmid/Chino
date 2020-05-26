using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerHurtBox : MonoBehaviour
{
    public GameObject playerCam, bossFace;
    GameObject stunAbilityObj, bossGameobject;

    public AudioSource bossScareSound, defeatSound, bossFollowMusic;

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
            StartCoroutine(lookAtBossTimer());

            bossGameobject.GetComponent<BossMovement>().alreadyInChase = true;
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
        else if(other.gameObject.tag == "TutorialBoss")
        {
            print("player hit");
            TutorialManager tutorialScript = GameObject.Find("Tutorial").GetComponent<TutorialManager>();
            tutorialScript.DoSkillCheck();
        }
    }

    public void PlayerDied()
    {
        print("You died");
        bossFollowMusic.Stop();
        defeatSound.Play();
    }

    IEnumerator lookAtBossTimer()
    {
        bossScareSound.Play();
        lookAtBoss = true;
        yield return new WaitForSeconds(1.5f);
        lookAtBoss = false;
    }
}
