using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public int usableNumber;

    public int[] addItemIds;
    public GameObject[] addItemObj;
    int testNumber;

    public AudioSource gettingReadyStart, gettingReady, phoneRingingSound;

    public bool phoneReady;

    public void TestIfComplete()
    {
        testNumber++;

        if (testNumber == addItemIds.Length)
        {
            StartCoroutine(ItemsAddedOn());
        }
    }

    public void HitThePhone()
    {
        if(phoneReady == true)
        {
            print("Finised");
        }
    }

    IEnumerator ItemsAddedOn()
    {
        gettingReadyStart.Play();
        yield return new WaitForSeconds(0.88f);
        gettingReady.Play();
        yield return new WaitForSeconds(30);
        phoneRingingSound.Play();
        phoneReady = true;
    }
}
