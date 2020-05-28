using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampAnimSelector : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = this.GetComponent<Animator>();

        int randomNumber = Random.Range(1, 4);

        if (randomNumber == 1)
        {
            anim.SetInteger("LightSelector", 1);
        }
        if (randomNumber == 2)
        {
            anim.SetInteger("LightSelector", 2);
        }
        if (randomNumber == 3)
        {
            anim.SetInteger("LightSelector", 3);
        }
    }
 }
