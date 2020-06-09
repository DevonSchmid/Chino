using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDoor : MonoBehaviour
{
    public int[] addItemIds;
    public GameObject[] addItemObj;
    public int itemCount = 0;
    public int openingTime;
    public AudioSource creekingSound, leverSound;

    bool runOnce;

    private void Start()
    {
        print(LevelManager.levelNumber);
    }

    public void escapeTroughHatch()
    {
        if(runOnce == false)
        {
            runOnce = true;
            print("escape");
            LevelManager.levelNumber++;
            SceneManager.LoadScene("MainMenu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public IEnumerator openingHatch()
    {
        this.GetComponent<Animator>().SetTrigger("Open");
        leverSound.Play();
        creekingSound.Play();
        yield return new WaitForSeconds(openingTime);
        print("open");
        creekingSound.Stop();
        itemCount = 4;
    }
}
