using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            anim.SetBool("IsCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            anim.SetBool("IsCrouching", false);
        }

        if (Input.GetButton("Crouch") && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            anim.SetBool("IsCrouchWalking", true);
        }
        if((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if (Input.GetButtonDown("Run"))
        {
            anim.SetBool("IsRunning", true);
        }
        else if (Input.GetButtonUp("Run"))
        {
            anim.SetBool("IsRunning", false);
        }
    }
}
