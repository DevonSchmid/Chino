using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource woodWalk, concreteWalk, stoneWalk, metalWalk, breathingWalk, breathingRun, breathingCrouch;
    public bool runOnce;
    public float addTimeToWalkTimer, addTimeToRunTimer, addTimeToCrouchTimer;
    float walkTimer, runTimer, crouchTimer;

    public int walkingState;

    public string floorType;
    GameObject floorTypeObj;

    private void Update()
    {
        SoundsPlay();

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) 
        {
            if(!Input.GetButton("Run") && !Input.GetButton("Crouch"))
            {
                if (runOnce == true)
                {
                    runOnce = false;
                    breathingWalk.Play();
                    walkingState = 1;
                    walkTimer = addTimeToWalkTimer;

                    if (floorTypeObj.tag == "WoodFloor")
                    {
                        woodWalk.pitch = Random.Range(1f, 1.5f);
                        woodWalk.Play();
                    }
                    if (floorTypeObj.tag == "ConcreteFloor")
                    {
                        concreteWalk.pitch = Random.Range(0.5f, 1.5f);
                        concreteWalk.Play();
                    }
                    if (floorTypeObj.tag == "StoneFloor")
                    {
                        stoneWalk.pitch = Random.Range(0.5f, 1.5f);
                        stoneWalk.Play();
                    }
                    if (floorTypeObj.tag == "MetalFloor")
                    {
                        metalWalk.pitch = Random.Range(0.5f, 1.5f);
                        metalWalk.Play();
                    }
                }
            }
            
            if (Input.GetButtonDown("Run") && !Input.GetButton("Crouch"))
            {
                walkingState = 2;
                breathingWalk.Stop();
                breathingRun.Play();
                runTimer = addTimeToRunTimer;

                if (floorTypeObj.tag == "WoodFloor")
                {
                    woodWalk.pitch = Random.Range(1f, 1.5f);
                    woodWalk.Play();
                    runTimer = addTimeToRunTimer;
                }
                if (floorTypeObj.tag == "ConcreteFloor")
                {
                    concreteWalk.pitch = Random.Range(0.5f, 1.5f);
                    concreteWalk.Play();
                    runTimer = addTimeToRunTimer;
                }
                if (floorTypeObj.tag == "StoneFloor")
                {
                    stoneWalk.pitch = Random.Range(0.5f, 1.5f);
                    stoneWalk.Play();
                    runTimer = addTimeToRunTimer;
                }
                if (floorTypeObj.tag == "MetalFloor")
                {
                    metalWalk.pitch = Random.Range(0.5f, 1.5f);
                    metalWalk.Play();
                    runTimer = addTimeToRunTimer;
                }
            }
            else if(Input.GetButtonUp("Run"))
            {
                breathingRun.Stop();
                runOnce = true;
            }


            if(!Input.GetButton("Run") && Input.GetButtonDown("Crouch"))
            {
                walkingState = 3;
                breathingWalk.Stop();
                breathingCrouch.Play();
                crouchTimer = addTimeToCrouchTimer;

                if (floorTypeObj.tag == "WoodFloor")
                {
                    woodWalk.pitch = Random.Range(1f, 1.5f);
                    woodWalk.Play();
                    crouchTimer = addTimeToCrouchTimer;
                }
                if (floorTypeObj.tag == "ConcreteFloor")
                {
                    concreteWalk.pitch = Random.Range(0.5f, 1.5f);
                    concreteWalk.Play();
                    crouchTimer = addTimeToCrouchTimer;
                }
                if (floorTypeObj.tag == "StoneFloor")
                {
                    stoneWalk.pitch = Random.Range(0.5f, 1.5f);
                    stoneWalk.Play();
                    crouchTimer = addTimeToCrouchTimer;
                }
                if (floorTypeObj.tag == "MetalFloor")
                {
                    metalWalk.pitch = Random.Range(0.5f, 1.5f);
                    metalWalk.Play();
                    crouchTimer = addTimeToCrouchTimer;
                }
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                breathingCrouch.Stop();
                breathingWalk.Play();
                runOnce = true;
            }

        }
        else
        {
            walkingState = 0;
            breathingWalk.Stop();
            breathingRun.Stop();
            breathingCrouch.Stop();
            runOnce = true;
        }

    }

    void SoundsPlay()
    {
        if(walkingState == 1)
        {
            if (walkTimer >= 0.00000001)
            {
                walkTimer -= Time.deltaTime;
            }
            if (walkTimer <= -0.0000001)
            {
                if (floorTypeObj.tag == "WoodFloor")
                {
                    woodWalk.pitch = Random.Range(1f, 1.5f);
                    woodWalk.Play();
                }
                if (floorTypeObj.tag == "ConcreteFloor")
                {
                    concreteWalk.pitch = Random.Range(0.5f, 1.5f);
                    concreteWalk.Play();
                }
                if (floorTypeObj.tag == "StoneFloor")
                {
                    stoneWalk.pitch = Random.Range(0.5f, 1.5f);
                    stoneWalk.Play();
                }
                if (floorTypeObj.tag == "MetalFloor")
                {
                    metalWalk.pitch = Random.Range(0.5f, 1.5f);
                    metalWalk.Play();
                }
                walkTimer = addTimeToWalkTimer;
            }
        }

        if(walkingState == 2)
        {
            if (runTimer >= 0.00000001)
            {
                runTimer -= Time.deltaTime;
            }
            else if (runTimer <= -0.0000001)
            {
                if (floorTypeObj.tag == "WoodFloor")
                {
                    woodWalk.pitch = Random.Range(1f, 1.5f);
                    woodWalk.Play();
                    runTimer = addTimeToRunTimer;
                }
                if (floorTypeObj.tag == "ConcreteFloor")
                {
                    concreteWalk.pitch = Random.Range(0.5f, 1.5f);
                    concreteWalk.Play();
                    runTimer = addTimeToRunTimer;
                }
                if (floorTypeObj.tag == "StoneFloor")
                {
                    stoneWalk.pitch = Random.Range(0.5f, 1.5f);
                    stoneWalk.Play();
                    runTimer = addTimeToRunTimer;
                }
                if (floorTypeObj.tag == "MetalFloor")
                {
                    metalWalk.pitch = Random.Range(0.5f, 1.5f);
                    metalWalk.Play();
                    runTimer = addTimeToRunTimer;
                }
            }
        }
        if (walkingState == 3)
        {
            if (crouchTimer >= 0.00000001)
            {
                crouchTimer -= Time.deltaTime;
            }
            else if (crouchTimer <= -0.0000001)
            {
                if (floorTypeObj.tag == "WoodFloor")
                {
                    woodWalk.pitch = Random.Range(1f, 1.5f);
                    woodWalk.Play();
                    crouchTimer = addTimeToCrouchTimer;
                }
                if (floorTypeObj.tag == "ConcreteFloor")
                {
                    concreteWalk.pitch = Random.Range(0.5f, 1.5f);
                    concreteWalk.Play();
                    crouchTimer = addTimeToCrouchTimer;
                }
                if (floorTypeObj.tag == "StoneFloor")
                {
                    stoneWalk.pitch = Random.Range(0.5f, 1.5f);
                    stoneWalk.Play();
                    crouchTimer = addTimeToCrouchTimer;
                }
                if (floorTypeObj.tag == "MetalFloor")
                {
                    metalWalk.pitch = Random.Range(0.5f, 1.5f);
                    metalWalk.Play();
                    crouchTimer = addTimeToCrouchTimer;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        floorTypeObj = other.gameObject;
    }
}
