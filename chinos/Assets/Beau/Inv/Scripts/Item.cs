using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public int itemId;
    public Sprite itemSprite;
    public GameObject seeTroughWallsObj;

    private void Start()
    {
        if (CheatCode.showItActivated == true)
        {
            seeTroughWallsObj.SetActive(true);
        }
    }
}
