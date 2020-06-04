using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    public RaycastHit hit;
    public float useRange;

    public Inventory inventory;

    public GameObject crossHair;

    public AudioSource pickUpSound, useSound;

    public Animator anim;

    private void Update()
    { 

        Debug.DrawRay(transform.position, transform.forward * useRange, Color.green);

        if(Physics.Raycast(transform.position, transform.forward, out hit, useRange))
        {
            if(hit.collider.gameObject.tag == "Item" || hit.collider.gameObject.tag == "Generator" || hit.collider.gameObject.tag == "Planks")
            {
                crossHair.SetActive(true);
            }
            else
            {
                crossHair.SetActive(false);
            }

            if (Input.GetButtonDown("Pickup"))
            {
                if (hit.collider.gameObject.tag == "Item")
                {
                    anim.SetTrigger("PickUp");
                    pickUpSound.Play();
                    AddItem(hit.collider.gameObject.transform.parent.gameObject);
                }
                if(hit.collider.gameObject.tag == "Generator")
                {
                    Generator(hit.collider.gameObject.transform.parent.gameObject);
                }
                if (hit.collider.gameObject.tag == "Planks")
                {
                    Planks(hit.collider.gameObject.transform.parent.gameObject, hit.collider.gameObject);
                }
            }
        }
        else
        {
            crossHair.SetActive(false);
        }
    }
    void AddItem(GameObject pickUpObject)
    {
        for(int i = 0; i < inventory.slots.Length; i++)
        {
            if(inventory.slots[i].gameObject.GetComponent<Slot>().itemId == 0)
            {
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

    void Generator(GameObject usableItem)
    {
        for(int i = 0; i < usableItem.GetComponent<GeneratorScript>().addItemIds.Length; i++)
        {
            if (usableItem.GetComponent<GeneratorScript>().addItemIds[i] == inventory.slots[0].GetComponent<Slot>().itemId)
            {
                useSound.Play();
                usableItem.GetComponent<GeneratorScript>().addItemObj[i].gameObject.SetActive(true);
                inventory.slots[0].GetComponent<Slot>().itemName = null;
                inventory.slots[0].GetComponent<Slot>().itemId = 0;
                inventory.slots[0].GetComponent<Slot>().itemSprite = null;
                inventory.slots[0].GetComponent<Slot>().GetComponent<Image>().sprite = inventory.standardImage;

                inventory.RerangeItems();
                usableItem.GetComponent<GeneratorScript>().TestIfComplete();
                return;
            }
            else if (usableItem.GetComponent<GeneratorScript>().phoneReady == true || usableItem.GetComponent<GeneratorScript>().readyForTutorial == true)
            {
                usableItem.GetComponent<GeneratorScript>().HitThePhone();
            }
        }
    }
    void Planks(GameObject usableItem, GameObject usableItemChild)
    {
        for(int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].gameObject.GetComponent<Slot>().itemId == 3)
            {
                if(usableItem.GetComponent<Planks>().planksLeft > 3)
                {
                    //use crowbar until it breaks
                    Destroy(usableItemChild);
                    usableItem.GetComponent<Planks>().planksLeft--;
                    break;
                }
                else if (usableItem.GetComponent<Planks>().planksLeft == 3)
                {
                    for(int p =0; p < inventory.slots.Length; p++)
                    {
                        if (inventory.slots[p].gameObject.GetComponent<Slot>().itemId == 5)
                        {
                            //repair crowbar
                            usableItem.GetComponent<Planks>().planksLeft--;
                            inventory.slots[p].GetComponent<Slot>().itemName = null;
                            inventory.slots[p].GetComponent<Slot>().itemId = 0;
                            inventory.slots[p].GetComponent<Slot>().itemSprite = null;
                            inventory.slots[p].GetComponent<Slot>().GetComponent<Image>().sprite = inventory.standardImage;
                            inventory.slots[i].gameObject.GetComponent<Image>().sprite = usableItem.GetComponent<Planks>().crowbarWithTape;
                            break;
                        }
                    }
                }
                else if(usableItem.GetComponent<Planks>().planksLeft == 2)
                {
                    Destroy(usableItemChild);
                    usableItem.GetComponent<Planks>().planksLeft--;
                    inventory.slots[i].GetComponent<Slot>().itemName = null;
                    inventory.slots[i].GetComponent<Slot>().itemId = 0;
                    inventory.slots[i].GetComponent<Slot>().itemSprite = null;
                    inventory.slots[i].GetComponent<Slot>().GetComponent<Image>().sprite = inventory.standardImage;
                }
            }
            else if(inventory.slots[i].gameObject.GetComponent<Slot>().itemId == 4 && usableItem.GetComponent<Planks>().planksLeft == 1)
            {
                usableItem.GetComponent<Planks>().planksLeft--;
                inventory.slots[i].GetComponent<Slot>().itemName = null;
                inventory.slots[i].GetComponent<Slot>().itemId = 0;
                inventory.slots[i].GetComponent<Slot>().itemSprite = null;
                inventory.slots[i].GetComponent<Slot>().GetComponent<Image>().sprite = inventory.standardImage;
            }
            else if(usableItem.GetComponent<Planks>().planksLeft == 0)
            {
                //escape
                usableItem.GetComponent<Planks>().startIenumerator();
            }
        }
    }
}
