using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usables : MonoBehaviour
{
    public int usableNumber;

    public int[] addItemIds;
    public GameObject[] addItemObj;
    public int testNumber;

    public void TestIfComplete()
    {
        for(int i = 0; i < addItemObj.Length; i++)
        {
            if(addItemObj[i].activeSelf == true)
            {
                testNumber++;
                if(testNumber == addItemObj.Length)
                {
                    print(gameObject.name + " is finished");
                }
            }
        }
    }
}
