using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    public GameObject[] locations;
    public GameObject bossLocationsEmptyGameObject, player,playerSoundLoc;

    int randomLocationNumber;

    public NavMeshAgent bossAgent;

    public Vector3 newLocation, oldLocation;

    public float timer;
    int addTimeToTimer;

    public bool hasRunned = false;

    private void Start()
    {
        setupBossLocationArray();
        bossAgent = this.GetComponent<NavMeshAgent>();
        RandomLocationNumberGenerator();
    }

    private void Update()
    {
        
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

    public void PlayerAsLocation()
    {
        playerSoundLoc.transform.position = new Vector3(player.transform.position.x, playerSoundLoc.transform.position.y, player.transform.position.z);
    }
}
