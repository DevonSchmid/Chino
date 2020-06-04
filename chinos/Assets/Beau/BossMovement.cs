using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class BossMovement : MonoBehaviour
{
    [HideInInspector] public GameObject[] locations;
    public GameObject bossLocationsEmptyGameObject, player,playerSoundLoc;

    int randomLocationNumber;

    [HideInInspector] public NavMeshAgent bossAgent;
    public float bossSpeed, bossRunSpeed;

    [HideInInspector] public Vector3 newLocation, oldLocation;

    Animator anim;
    
    float timer;
    public int setTimeToTimer;

    public bool hasRunned1 = false, alreadyInChase = false;
    [HideInInspector] public bool settingPlayerAsLocBool;

    public AudioSource hearingPlayerSound, followingMusic, bossFootStep;

    private void Start()
    {
        setupBossLocationArray();
        anim = this.GetComponentInChildren<Animator>();
        bossAgent = this.GetComponent<NavMeshAgent>();
        bossAgent.speed = bossSpeed;
        RandomLocationNumberGenerator();
    }

    private void Update()
    {
        FootStepTimer();

        Timer();
        SettingNewLocationAsPlayer();
    }

    public void setupBossLocationArray()
    {
        for (int i = 0; i < locations.Length; i++)
        {
            locations[i] = bossLocationsEmptyGameObject.transform.GetChild(i).gameObject;
        }
    }

    public void RandomLocationNumberGenerator()
    {
        randomLocationNumber = Random.Range(0, locations.Length);

        NewLocationSelector();
    }

    public void NewLocationSelector()
    {
        oldLocation = newLocation;
        newLocation = locations[randomLocationNumber].transform.position;

        if(newLocation == oldLocation)
        {
            RandomLocationNumberGenerator();
        }
        else
        {
            bossAgent.SetDestination(newLocation);
            print("walking");
            anim.SetBool("IsTired", false);
            anim.SetBool("IsWalking", true);
        }
    }

    public void HearingPLayer()
    {
        if (hasRunned1 == false && alreadyInChase == false)
        {
            hasRunned1 = true;

            anim.SetBool("IsTired", false);
            anim.SetBool("IsWalking", false); 
            anim.SetBool("HearingPlayer", true);
            hearingPlayerSound.Play();

            timer = setTimeToTimer;
            bossAgent.speed = 0;
        }
        playerSoundLoc.transform.position = new Vector3(player.transform.position.x, playerSoundLoc.transform.position.y, player.transform.position.z);
    }

    void Timer()
    {
        if(timer >= 0.0000001)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= -0.00000001)
        {
            timer = 0;
            followingMusic.Play();
            bossAgent.speed = bossRunSpeed;
            settingPlayerAsLocBool = true;
            anim.SetBool("HearingPlayer", false);
            anim.SetBool("RunningToPlayer", true);
        }
    }

    void SettingNewLocationAsPlayer()
    {
        if(settingPlayerAsLocBool == true)
        {
            bossAgent.SetDestination(playerSoundLoc.transform.position);
        }
    }

    public float addWalkTime, addRunTime;
    public float footStepTimer;
    void FootStepTimer()
    {
        if (bossAgent.speed != 0)
        {
            if (footStepTimer >= 0.000000001f)
            {
                footStepTimer -= Time.deltaTime;
            }
            else if (footStepTimer <= 0)
            {
                bossFootStep.pitch = Random.Range(0.6f, 0.8f);
                bossFootStep.Play();
                if(bossAgent.speed == bossSpeed)
                {
                    footStepTimer = addWalkTime;
                }
                else if(bossAgent.speed == bossRunSpeed)
                {
                    footStepTimer = addRunTime;
                }
            }
        }
    }
}
