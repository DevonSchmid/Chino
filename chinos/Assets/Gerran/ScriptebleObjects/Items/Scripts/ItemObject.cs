using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new scripteble object", menuName ="inventory System/Item")]
public class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public int id;
    public Sprite sprite;
}
