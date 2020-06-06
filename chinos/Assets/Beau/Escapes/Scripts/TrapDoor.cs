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

    public void addItem()
    {
        if(itemCount == 2)
        {
            this.GetComponent<Collider>().enabled = false;
            addItemObj[0].GetComponent<Collider>().enabled = true;
        }
    }

    public void escapeTroughHatch()
    {
        print("escape");
        print(LevelManager.levelNumber);
        LevelManager.levelNumber++;
        print(LevelManager.levelNumber);
        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public IEnumerator openingHatch()
    {
        yield return new WaitForSeconds(openingTime);
        itemCount = 3;
        this.GetComponent<Collider>().enabled = true;
        addItemObj[0].GetComponent<Collider>().enabled = false;
        print("open");
    }
}
