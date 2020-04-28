using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeRandomizer : MonoBehaviour
{
    public int AmountEscapes;
    int randomEscapeNumber;

    public GameObject[] Escape1;

    private void Start()
    {
        randomEscapeNumber = Random.Range(1, AmountEscapes);
        if(randomEscapeNumber == 1)
        {
            Escape1Setup();
        }
    }

    void Escape1Setup()
    {
        int randomNumber1 = Random.Range(1, 4);
        if (randomNumber1 == 1)
        {
            Escape1[0].SetActive(true);
        }
        if (randomNumber1 == 2)
        {
            Escape1[1].SetActive(true);
        }
        if (randomNumber1 == 3)
        {
            Escape1[2].SetActive(true);
        }
        int randomNumber2 = Random.Range(1, 4);
        if (randomNumber2 == 1)
        {
            Escape1[3].SetActive(true);
        }
        if (randomNumber2 == 2)
        {
            Escape1[4].SetActive(true);
        }
        if (randomNumber2 == 3)
        {
            Escape1[5].SetActive(true);
        }
        int randomNumber3 = Random.Range(1, 4);
        if (randomNumber3 == 1)
        {
            Escape1[6].SetActive(true);
        }
        if (randomNumber3 == 2)
        {
            Escape1[7].SetActive(true);
        }
        if (randomNumber3 == 3)
        {
            Escape1[8].SetActive(true);
        }
    }
}
