using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.AI;

public class TutorialBoss : MonoBehaviour
{
    public AudioSource alertingSound;
    NavMeshAgent tutorialBossAgent;
    public int locNumber;
    public GameObject player;
    public GameObject[] bossMoveToLoc;
    public bool setPlayerLocAsLoc = true;
    Rigidbody rb;

    private void Start()
    {
        tutorialBossAgent = this.GetComponent<NavMeshAgent>();
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(setPlayerLocAsLoc == true)
        {
            tutorialBossAgent.destination = player.transform.position;
        }
    }

    public void NewLocation()
    {
        locNumber += 1;
        tutorialBossAgent.destination = bossMoveToLoc[locNumber].transform.position;
    }
    public void StandStill()
    {
        tutorialBossAgent.speed = 0;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
