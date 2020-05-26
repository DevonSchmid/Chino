using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public int usableNumber;

    public int[] addItemIds;
    public GameObject[] addItemObj;
    int testNumber;
    public int waitingTime = 30;

    public AudioSource gettingReadyStart, gettingReady, phoneRingingSound;

    public bool phoneReady, gettingReadyFinished, generatorForTutorialFinsihed;

    public GameObject seeTroughWallsObj;

    public bool inTutorial, readyForTutorial;

    private void Start()
    {
        if(CheatCode.showItActivated == true)
        {
            seeTroughWallsObj.SetActive(true);
        }
    }

    public void TestIfComplete()
    {
        testNumber++;

        if (testNumber == addItemIds.Length)
        {
            StartCoroutine(ItemsAddedOn());
            gettingReadyFinished = true;
        }
    }

    public void HitThePhone()
    {
        if(phoneReady == true && inTutorial == false)
        {
            print("Finised");
        }
        else if(inTutorial == true && readyForTutorial == true)
        {
            generatorForTutorialFinsihed = true;
        }
    }

    IEnumerator ItemsAddedOn()
    {
        gettingReadyStart.Play();
        yield return new WaitForSeconds(0.88f);
        gettingReady.Play();
        yield return new WaitForSeconds(waitingTime);
        phoneRingingSound.Play();
        phoneReady = true;
    }
}
