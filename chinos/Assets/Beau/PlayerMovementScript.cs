using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float fbspeed, lrspeed, runMultiplier, crouchDevider, crouchTransfrom;
    float fbRunSpeed, lrRunSpeed, fbCrouchSpeed, movementFbSpeed, movementLrSpeed;
    Rigidbody rb;

    private void Start()
    {
        movementFbSpeed = fbspeed;
        movementLrSpeed = lrspeed;
    }

    void Update()
    {
        float Lr = Input.GetAxis("Horizontal") * Time.deltaTime * movementLrSpeed;
        float Fb = Input.GetAxis("Vertical") * Time.deltaTime * movementFbSpeed;

        transform.Translate(Lr, 0, Fb);

        if (Input.GetButtonDown("Run"))
        {
            movementFbSpeed *= runMultiplier;
            movementLrSpeed *= runMultiplier;
        }
        if (Input.GetButtonUp("Run"))
        {
            movementFbSpeed = fbspeed;
            movementLrSpeed = lrspeed;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            transform.localScale = new Vector3(1, crouchTransfrom, 1);
            movementFbSpeed /= crouchDevider;
            movementLrSpeed /= crouchDevider;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            transform.localScale = new Vector3(1, 1, 1);
            movementFbSpeed = fbspeed;
            movementLrSpeed = lrspeed;
        }
    }
}
