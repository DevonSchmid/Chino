using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EngeneersHandsScript : PassiveAbility
{
    public GameObject[] objectsWithTimer, secondObj;
    public GameObject player, buttonManeger;
    public float divider;
    public float multiplier;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        if (!objectsWithTimer[0])
        {
            objectsWithTimer[0].GetComponent<GeneratorScript>().waitingTime *= multiplier;
            objectsWithTimer[1].GetComponent<GeneratorScript>().waitingTime *= multiplier;
            objectsWithTimer[2].GetComponent<GeneratorScript>().waitingTime *= multiplier;
            player.GetComponent<PlayerMovementScript>().fbspeed *= divider;
            player.GetComponent<PlayerMovementScript>().lrspeed *= divider;
        }

        else if (objectsWithTimer[0])
        {
            if(SceneManager.GetActiveScene().name == "Level2")
            {
                for (int i = 0; i < secondObj.Length; i++)
                {

                    if (secondObj[i].activeSelf == true)
                    {
                        secondObj[i].GetComponent<Item>().seeTroughWallsObj.SetActive(true);
                    }
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level4")
            {
                buttonManeger.GetComponent<ButtonManager>().buttonOrder[0].GetComponent<Button>().seeTroughWallsObj.SetActive(true);
            }


        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
