using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usables : MonoBehaviour
{
    public int usableNumber;

    public int[] addItemIds;
    public GameObject[] addItemObj;
    public int testNumber;

    public AudioSource gettingReadyStart, gettingReady;

    public void TestIfComplete()
    {
        testNumber++;

        if(testNumber == addItemIds.Length)
        {
            StartCoroutine(ItemsAddedOn());
        }
        /*
        for(int i = 0; i < addItemObj.Length; i++)
        {
            if(addItemObj[i].activeSelf == true)
            {
                testNumber++;   
                if(testNumber == addItemObj.Length)
                {
                    ItemsAddedOn();
                }
            }
        }
        */
    }

    IEnumerator ItemsAddedOn()
    {
        gettingReadyStart.Play();
        yield return new WaitForSeconds(0.88f);
        gettingReady.Play();
        yield return new WaitForSeconds(30);
        //phone Sound
        print("ready");
    }
}
