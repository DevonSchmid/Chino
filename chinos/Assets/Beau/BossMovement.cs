using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    [HideInInspector] public GameObject[] locations;
    public GameObject bossLocationsEmptyGameObject, player,playerSoundLoc;

    int randomLocationNumber;

    [HideInInspector] public NavMeshAgent bossAgent;
    public float bossSpeed, bossRunSpeed;

    [HideInInspector] public Vector3 newLocation, oldLocation;

    
    float timer;
    public int setTimeToTimer;

    [HideInInspector] public bool hasRunned1 = false;
    [HideInInspector] public bool settingPlayerAsLocBool;

    private void Start()
    {
        setupBossLocationArray();
        bossAgent = this.GetComponent<NavMeshAgent>();
        bossAgent.speed = bossSpeed;
        RandomLocationNumberGenerator();
    }

    private void Update()
    {
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
        }
    }

    public void HearingPLayer()
    {
        playerSoundLoc.transform.position = new Vector3(player.transform.position.x, playerSoundLoc.transform.position.y, player.transform.position.z);

        if(hasRunned1 == false)
        {
            hasRunned1 = true;
            timer = setTimeToTimer;
            bossAgent.speed = 0;
        }
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
            bossAgent.speed = bossRunSpeed;
            settingPlayerAsLocBool = true;
        }
    }

    void SettingNewLocationAsPlayer()
    {
        if(settingPlayerAsLocBool == true)
        {
            bossAgent.SetDestination(playerSoundLoc.transform.position);
        }
    }
}
