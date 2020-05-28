using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="New Inventory", menuName = "inventory System/Inventory")]
public class InvetoryObjects : ScriptableObject
{
    /*
    public int e;
    public List<InventorySlot> Container = new List<InventorySlot>();
    public Image[] slots;
    public void AddItem(ItemObject _item)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            e = i;
            if(Container[i].item == _item)
            {
                hasItem = true;
                break;
            }
        }
        if(!hasItem)
        {
            Container.Add(new InventorySlot(_item));
            slots[e].sprite = Container[e].item.sprite;
        }
    }
    */
}
[System.Serializable]
public class InventorySlot
{
    /*
    public ItemObject item;
    public InventorySlot(ItemObject _item)
    {
        item = _item;
    }
    */
}
