using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator anim, camAnim;
    public new GameObject camera;
    private void Start()
    {
        anim = this.GetComponent<Animator>();
        camAnim = camera.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            anim.SetBool("IsCrouching", true);
            camAnim.SetBool("IsCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            anim.SetBool("IsCrouching", false);
            camAnim.SetBool("IsCrouching", false);
        }

        if((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            anim.SetBool("IsWalking", true);
            camAnim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
            camAnim.SetBool("Moving", false);
        }

        if (Input.GetButtonDown("Run"))
        {
            anim.SetBool("IsRunning", true);
            camAnim.SetBool("IsRunning", true);
        }
        else if (Input.GetButtonUp("Run"))
        {
            anim.SetBool("IsRunning", false);
            camAnim.SetBool("IsRunning", false);
        }
    }
}
