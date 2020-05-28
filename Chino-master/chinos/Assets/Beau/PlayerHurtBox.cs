using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerHurtBox : MonoBehaviour
{
    public GameObject playerCam, bossFace;
    public GameObject stunAbilityObj, bossGameobject;
    public GameObject deathScreen;
    bool hasRunned;
    IEnumerator coroutine;

    public AudioSource bossScareSound, bossFollowMusic;

    bool lookAtBoss;
    private void Start()
    {
        bossGameobject = GameObject.Find("Boss");
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
                coroutine = PlayerDied();
                StartCoroutine(coroutine);
            }
        }
        else if(other.gameObject.tag == "TutorialBoss")
        {
            print("player hit");
            TutorialManager tutorialScript = GameObject.Find("Tutorial").GetComponent<TutorialManager>();
            tutorialScript.DoSkillCheck();
        }
    }

    public void PlayerDiedNumerator()
    {
        coroutine = PlayerDied();
        StartCoroutine(coroutine);
    }
    public IEnumerator PlayerDied()
    {
        if(hasRunned == false)
        {
            hasRunned = true;
            yield return new WaitForSeconds(.5f);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            bossFollowMusic.Stop();
            deathScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator lookAtBossTimer()
    {
        bossScareSound.Play();
        lookAtBoss = true;
        yield return new WaitForSeconds(1.5f);
        lookAtBoss = false;
    }
}
