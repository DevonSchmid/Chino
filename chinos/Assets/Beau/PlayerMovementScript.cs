using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementScript : MonoBehaviour
{
    public float fbspeed, lrspeed, runMultiplier, crouchDevider, crouchTransfrom;
    float fbRunSpeed, lrRunSpeed, fbCrouchSpeed;
    public float movementFbSpeed, movementLrSpeed;

    public float[] radias;

    public Image soundImage;
    public Sprite sound1, sound2, sound3, sound4;

    public bool ableToMove = true;

    SphereCollider radiusCol;

    private void Start()
    {
        radiusCol = GameObject.Find("AlertingRadius").GetComponent<SphereCollider>();

        movementFbSpeed = fbspeed;
        movementLrSpeed = lrspeed;
    }

    void Update()
    {
        Strave();
        Walk();
        Run();
        Crouch();
        SetAlertColRadius();

    }

    public void Strave()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            movementFbSpeed *= .7f;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movementFbSpeed = fbspeed;
            if (Input.GetButton("Run"))
            {
                movementFbSpeed *= runMultiplier;
            }
            if (Input.GetButton("Crouch"))
            {
                movementFbSpeed /= crouchDevider;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movementFbSpeed *= .7f;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movementFbSpeed = fbspeed;
            if (Input.GetButton("Run"))
            {
                movementFbSpeed *= runMultiplier;
            }
            if (Input.GetButton("Crouch"))
            {
                movementFbSpeed /= crouchDevider;
            }
        }
    }

    float Lr, Fb;

    public void Walk()
    {
        if (ableToMove == true)
        {
            Lr = Input.GetAxis("Horizontal") * Time.deltaTime * movementLrSpeed;
            Fb = Input.GetAxis("Vertical") * Time.deltaTime * movementFbSpeed;

            movementFbSpeed = Mathf.Clamp(movementFbSpeed, 0, 6);
            transform.Translate(Lr, 0, Fb);
        }
    }

    public GameObject owlsEarGameObj;
    public void SetAlertColRadius()
    {
        if (Lr == 0 && Fb == 0)
        {
            if (Input.GetButton("Crouch") && !Input.GetButton("Run"))
            {
                radiusCol.radius = radias[0];
                soundImage.sprite = sound1;
            }
            else
            {
                radiusCol.radius = radias[1];
                soundImage.sprite = sound2;
            }
        }
        else
        {
            if(owlsEarGameObj.activeSelf == false)
            {
                if (movementFbSpeed == fbspeed * runMultiplier)
                {
                    radiusCol.radius = radias[3];
                    soundImage.sprite = sound4;
                }
                if (movementFbSpeed == fbspeed)
                {
                    radiusCol.radius = radias[2];
                    soundImage.sprite = sound3;
                }
                if (movementFbSpeed == fbspeed / crouchDevider)
                {
                    radiusCol.radius = radias[1];
                    soundImage.sprite = sound2;
                }
            }
            else if(owlsEarGameObj.activeSelf == true)
            {
                if (Input.GetButton("Run"))
                {
                    radiusCol.radius = radias[3];
                    soundImage.sprite = sound4;
                }
                else if (Input.GetButton("Crouch"))
                {
                    radiusCol.radius = radias[1];
                    soundImage.sprite = sound2;
                }
                else
                {
                    radiusCol.radius = radias[2];
                    soundImage.sprite = sound3;
                }
            }
            
        }
    }
    public void Run()
    {
        if (Input.GetButtonDown("Run") && !(Input.GetButton("Crouch")))
        {
            movementFbSpeed *= runMultiplier;
            movementLrSpeed *= runMultiplier;
        }
        if (Input.GetButtonUp("Run"))
        {
            movementFbSpeed = fbspeed;
            movementLrSpeed = lrspeed;
        }
    }
    public void Crouch()
    {
        if (Input.GetButtonDown("Crouch") && !(Input.GetButton("Run"))) 
        {
            transform.localScale = new Vector3(1, crouchTransfrom, 1);
            movementFbSpeed /= crouchDevider;
            movementLrSpeed /= crouchDevider;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            transform.localScale = new Vector3(1, 1, 1);
            movementFbSpeed = fbspeed;
            movementLrSpeed = lrspeed;
        }
    }
}
