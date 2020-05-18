using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    public RaycastHit hit;
    public float useRange;

    public Inventory inventory;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * useRange, Color.green);

        if (Input.GetKeyDown(KeyCode.F))
        {
            if(Physics.Raycast(transform.position, transform.forward, out hit, useRange))
            {
                if(hit.collider.gameObject.tag == "Item")
                {
                    AddItem(hit.collider.gameObject);
                }
                if(hit.collider.gameObject.tag == "Usable")
                {
                    UseUsable(hit.collider.gameObject);
                }
            }
        }
    }
    void AddItem(GameObject pickUpObject)
    {
        for(int i = 0; i < inventory.slots.Length; i++)
        {
            if(inventory.slots[i].gameObject.GetComponent<Slot>().itemId == 0)
            {
                print("picked up " + pickUpObject.name);

                Slot slotScript = inventory.slots[i].gameObject.GetComponent<Slot>();

                slotScript.itemName = pickUpObject.GetComponent<Item>().itemName;
                slotScript.itemId = pickUpObject.GetComponent<Item>().itemId;
                slotScript.itemSprite = pickUpObject.GetComponent<Item>().itemSprite;
                slotScript.GetComponent<Image>().sprite = pickUpObject.GetComponent<Item>().itemSprite;

                Destroy(pickUpObject);

                return;
            }
        }
    }

    void UseUsable(GameObject usableItem)
    {
        for(int i = 0; i < usableItem.GetComponent<Usables>().addItemIds.Length; i++)
        {
            if(usableItem.GetComponent<Usables>().addItemIds[i] == inventory.slots[0].GetComponent<Slot>().itemId)
            {
                print("Used " + usableItem.name + " with " + inventory.slots[0].GetComponent<Slot>().itemName);

                inventory.slots[0].GetComponent<Slot>().itemName = null;
                inventory.slots[0].GetComponent<Slot>().itemId = 0;
                inventory.slots[0].GetComponent<Slot>().itemSprite = null;
                inventory.slots[0].GetComponent<Slot>().GetComponent<Image>().sprite = null;

                inventory.RerangeItems();
                return;
            }
        }
    }
}
