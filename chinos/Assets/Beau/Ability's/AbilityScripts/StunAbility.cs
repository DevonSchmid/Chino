﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StunAbility : Abilitys
{
    public int addTimeToTimer, addTimeToTimerStun;
    public float timer;

    public GameObject skillCheckObj, playerSoundLocScript, playerHurtBox;
    public GameObject[] skillCheckOptions;
    GameObject bossGameobject;

    public AudioSource skillCheckSound;
    public Animator bossAnim;

    bool succes;

    public Collider bossColider;

    public override void Start()
    {
        base.Start();
        skillCheckObj.SetActive(false);
        bossGameobject = GameObject.Find("Boss");
        BossLocationsScript.timerDevider = 0.1f;
    }

    public override void Update()
    {
        base.Update();
        GoSkillCheck();
        Timer();

        if (skillCheckObj.GetComponent<Slider>().value == 100)
        {
            if(SceneManager.GetActiveScene().name != "Tutorial")
            {
                skillCheckObj.GetComponent<Slider>().value = 0;
                SkillCheckMissed();
            }
        }
    }

    public void GoSkillCheck()
    {
        if(skillCheckObj.activeSelf == true)
        {
            skillCheckObj.GetComponent<Slider>().value += 80 * Time.deltaTime;
        }
    }
    public void DoSkillCheck()
    {
        skillCheckSound.Play();
        int randomNumber = Random.Range(0, skillCheckOptions.Length);

        if (randomNumber == 0)
        {
            skillCheckOptions[0].SetActive(true);
        }
        if (randomNumber == 1)
        {
            skillCheckOptions[1].SetActive(true);
        }
        if (randomNumber == 2)
        {
            skillCheckOptions[2].SetActive(true);
        }

        skillCheckObj.SetActive(true);
    }

    public override void EPressed()
    {
        if(SceneManager.GetActiveScene().name != "Tutorial")
        {
            if (skillCheckOptions[0].activeSelf == true && skillCheckObj.GetComponent<Slider>().value >= 77 && skillCheckObj.GetComponent<Slider>().value <= 96)
            {
                SkillCheckSucces();
            }
            if (skillCheckOptions[1].activeSelf == true && skillCheckObj.GetComponent<Slider>().value >= 52 && skillCheckObj.GetComponent<Slider>().value <= 70)
            {
                SkillCheckSucces();
            }
            if (skillCheckOptions[2].activeSelf == true && skillCheckObj.GetComponent<Slider>().value >= 19 && skillCheckObj.GetComponent<Slider>().value <= 38)
            {
                SkillCheckSucces();
            }
            else if (skillCheckOptions[0].activeSelf == true || skillCheckOptions[1].activeSelf == true || skillCheckOptions[2].activeSelf == true)
            {
                SkillCheckMissed();
            }
        }
    }

    void SkillCheckMissed()
    {
        playerHurtBox.GetComponent<PlayerHurtBox>().PlayerDiedNumerator();
        skillCheckObj.SetActive(false);
    }

    void SkillCheckSucces()
    {
        bossGameobject.GetComponent<BossMovement>().alreadyInChase = true;
        playerSoundLocScript.GetComponent<PlayerSoundLocScript>().timer = 0;

        bossColider.enabled = false;

        bossAnim.SetBool("PickingUpPlayer", false);
        succes = true;
        skillCheckObj.GetComponent<Slider>().value = 0f;
        skillCheckOptions[0].SetActive(false); skillCheckOptions[1].SetActive(false); skillCheckOptions[2].SetActive(false);
        skillCheckObj.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerMovementScript>().ableToMove = true;
        timer = addTimeToTimerStun;
        abilityImageCover.rectTransform.sizeDelta = new Vector2(0, 100);
    }

    public void AddTimeToTimer()
    {
        if (abilityImageCover.rectTransform.sizeDelta.y == 0)
        {
            timer = addTimeToTimer;
        }
        else
        {
            playerHurtBox.GetComponent<PlayerHurtBox>().PlayerDiedNumerator();
        }
    }

    void Timer()
    {
        if(timer >= 0.00000001)
        {
            timer -= Time.deltaTime;
        }
        else if(timer <= -0.0000001)
        {
            timer = 0;
            if(succes == true)
            {
                succes = false;
                print("CanWalk");

                bossColider.enabled = true;

                Animator anim = bossGameobject.GetComponentInChildren<Animator>();
                anim.SetBool("PickedUpPlayer", false);
                anim.SetBool("IsWalking", true);
                bossGameobject.GetComponent<BossMovement>().hasRunned1 = false;
                bossGameobject.GetComponent<BossMovement>().alreadyInChase = false;
                bossGameobject.GetComponent<BossMovement>().bossAgent.speed = bossGameobject.GetComponent<BossMovement>().bossSpeed;
                bossGameobject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                bossGameobject.GetComponent<BossMovement>().RandomLocationNumberGenerator();
            }
            else
            {
                DoSkillCheck();
            }
        }
    }
}
