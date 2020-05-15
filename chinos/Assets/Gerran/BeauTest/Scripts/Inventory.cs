using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] slots;
    public GameObject[] usables;

    public void RerangeItems()
    {
        if (slots[0].GetComponent<Slot>().itemId == 0)
        {
            for(int i = 0; i < slots.Length; i++)
            {
                if(slots[i].GetComponent<Slot>().itemId != 0)
                {
                    slots[i - 1].GetComponent<Slot>().itemName = slots[i].GetComponent<Slot>().itemName;
                    slots[i - 1].GetComponent<Slot>().itemId = slots[i].GetComponent<Slot>().itemId;
                    slots[i - 1].GetComponent<Slot>().itemSprite = slots[i].GetComponent<Slot>().itemSprite;
                    slots[i - 1].GetComponent<Image>().sprite = slots[i].GetComponent<Image>().sprite;

                    slots[i].GetComponent<Slot>().itemName = null;
                    slots[i].GetComponent<Slot>().itemId = 0;
                    slots[i].GetComponent<Slot>().itemSprite = null;
                    slots[i].GetComponent<Image>().sprite = null;
                }
            }
        }
    }
}
