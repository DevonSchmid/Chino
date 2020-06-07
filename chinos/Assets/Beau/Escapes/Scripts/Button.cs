using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    bool alreadySetUp;
    Animator anim;
    public int buttonNumber;
    public GameObject spotLight, seeTroughWallsObj;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        if(CheatCode.showItActivated == true)
        {
            seeTroughWallsObj.SetActive(true);
        }
    }
}
