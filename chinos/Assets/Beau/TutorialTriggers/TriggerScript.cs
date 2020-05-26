using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public TutorialManager tutorialManager;
    bool hasPlayed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            tutorialManager.Trigger();
            Destroy(gameObject);
        }
    }
}
