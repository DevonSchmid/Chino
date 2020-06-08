using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject buttonsOutOrder, buttonsInOrder, box, key;
    public GameObject[] buttonOrder;
    int number;
    public AudioSource openBox;

    private void Start()
    {
        RandomButtonInput();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            OpenBox();
        }
    }

    void RandomButtonInput()
    {
        if(buttonsOutOrder.transform.childCount != 0)
        {
            GameObject randomButton = buttonsOutOrder.transform.GetChild(Random.Range(0, buttonsOutOrder.transform.childCount)).gameObject;
            randomButton.transform.parent = buttonsInOrder.transform;
            buttonOrder[number] = randomButton;
            number++;
            RandomButtonInput();
        }
    }
    public void OpenBox()
    {
        openBox.Play();
        box.GetComponent<Animator>().SetTrigger("Open");
        key.SetActive(true);
    }
}
