using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Planks : MonoBehaviour
{
    public int planksLeft;
    public GameObject inventory, doorHitbox, seeTroughWallsObj;
    public Sprite brokenCrowbar, crowbarWithTape;
    public AudioSource crowbarBreak, doorUnlockSound;

    public bool runOnce, runOnce2;

    private void Start()
    {
        print(LevelManager.levelNumber);
        if(CheatCode.showItActivated == true)
        {
            seeTroughWallsObj.SetActive(true);
        }
    }

    private void Update()
    {

        if (planksLeft == 3)
        {
            for(int i = 0; i < inventory.GetComponent<Inventory>().slots.Length; i++)
            {
                if(inventory.GetComponent<Inventory>().slots[i].gameObject.GetComponent<Slot>().itemId == 3 && runOnce == false)
                {
                    runOnce = true;
                    crowbarBreak.Play();
                    inventory.GetComponent<Inventory>().slots[i].gameObject.GetComponent<Image>().sprite = brokenCrowbar;
                }
            }
        }
        if(planksLeft == 2)
        {
            doorHitbox.SetActive(true);
        }
    }
    public void startIenumerator()
    {
        doorHitbox.SetActive(false);
        IEnumerator coroutine;
        coroutine = WaitForEscape();
        StartCoroutine(coroutine);
    }

    IEnumerator WaitForEscape()
    {
        if (runOnce2 == false)
        {
            runOnce2 = true;
            doorUnlockSound.Play();
            yield return new WaitForSeconds(3);
            print("escape");
            LevelManager.levelNumber++;
            print("Level " + LevelManager.levelNumber);
            SceneManager.LoadScene("MainMenu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
