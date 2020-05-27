using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planks : MonoBehaviour
{
    public int planksLeft = 2;
    public GameObject inventory;
    public Sprite brokenCrowbar, crowbarWithTape;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && planksLeft > 3)
        {
            planksLeft--;
            print(planksLeft);
        }

        if (planksLeft == 3)
        {
            for(int i = 0; i < inventory.GetComponent<Inventory>().slots.Length; i++)
            {
                if(inventory.GetComponent<Inventory>().slots[i].gameObject.GetComponent<Slot>().itemId == 3)
                {
                    inventory.GetComponent<Inventory>().slots[i].gameObject.GetComponent<Image>().sprite = brokenCrowbar;
                }
            }
        }
    }
}
