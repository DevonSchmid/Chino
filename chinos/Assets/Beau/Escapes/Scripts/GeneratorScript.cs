using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneratorScript : MonoBehaviour
{
    public int usableNumber;

    public int[] addItemIds;
    public GameObject[] addItemObj;
    int testNumber;
    public float waitingTime = 30;

    public AudioSource gettingReadyStart, gettingReady, phoneRingingSound;

    public bool phoneReady, gettingReadyFinished, generatorForTutorialFinsihed;

    public GameObject seeTroughWallsObj, bossGameobj, bossLocationObj;

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
            phoneReady = false;
            print("Finised");
            print(LevelManager.levelNumber);
            LevelManager.levelNumber++;
            print(LevelManager.levelNumber);
            SceneManager.LoadScene("MainMenu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
        bossGameobj.GetComponent<BossMovement>().bossAgent.SetDestination(bossLocationObj.transform.position);
        bossGameobj.GetComponent<BossMovement>().newLocation = bossLocationObj.transform.position;
        yield return new WaitForSeconds(waitingTime);
        phoneRingingSound.Play();
        phoneReady = true;
    }
}
