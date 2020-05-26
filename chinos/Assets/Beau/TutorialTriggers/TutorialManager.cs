using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;

    public GameObject lamp1, inventoryObj, generator1, door1, door2, door3;
    public GameObject invisibleWall1, invisibleWall2, invisibleWall3, invisibleWall4;

    public TutorialBoss bossScript;
    public AudioSource abilityReadySound;

    public GameObject skillCheckObj, skillCheckBackground;
    bool goSkillCheckBool;

    bool hasRunnedOnce1, hasRunnedOnce2, hasRunnedOnce3;

    public IEnumerator coroutine;

    int triggerNumber = 1;

    private void Start()
    {
        coroutine = StartTutorial();
        StartCoroutine(coroutine);
        generator1.GetComponent<GeneratorScript>().inTutorial = true;
    }

    private void Update()
    {
        if (inventoryObj.GetComponent<Inventory>().slots[1].GetComponent<Slot>().itemId != 0 && hasRunnedOnce1 == false)
        {
            hasRunnedOnce1 = true;
            StopCoroutine(coroutine);
            coroutine = Part2();
            StartCoroutine(coroutine);
        }
        if(generator1.GetComponent<GeneratorScript>().gettingReadyFinished == true && hasRunnedOnce2 == false)
        {
            hasRunnedOnce2 = true;
            StopCoroutine(coroutine);
            coroutine = Part3();
            StartCoroutine(coroutine);
        }
        if (generator1.GetComponent<GeneratorScript>().generatorForTutorialFinsihed == true && hasRunnedOnce3 == false)
        {
            hasRunnedOnce3 = true;
            StopCoroutine(coroutine);
            coroutine = Part4();
            StartCoroutine(coroutine);
        }
        if(goSkillCheckBool == true)
        {
            skillCheckObj.GetComponent<Slider>().value += 10 * Time.deltaTime;
        }
        if(skillCheckObj.activeSelf == true)
        {
            if (skillCheckObj.GetComponent<Slider>().value >= 52 && skillCheckObj.GetComponent<Slider>().value <= 70 && Input.GetButtonDown("Ability"))
            {
            print("SkillCheck Good");
                skillCheckObj.SetActive(false); skillCheckBackground.SetActive(false);
            }
            else if(Input.GetButtonDown("Ability"))
            {
                print("SkillCheck Failed");
                skillCheckObj.SetActive(false); skillCheckBackground.SetActive(false);
            }
            else if (skillCheckObj.GetComponent<Slider>().value == 100)
            {
            print("SkillCheck Failed");
                skillCheckObj.SetActive(false); skillCheckBackground.SetActive(false);
            }
        }
    }

    public void Trigger()
    {
        if(triggerNumber == 1)
        {
            triggerNumber = 2;
            StopCoroutine(coroutine);
            coroutine = Part1();
            StartCoroutine(coroutine);
        }
        else if(triggerNumber == 2)
        {
            triggerNumber = 3;
            StopCoroutine(coroutine);
            coroutine = Part5();
            StartCoroutine(coroutine);
        }
        else if(triggerNumber == 3)
        {
            triggerNumber = 4;
            invisibleWall1.SetActive(false);
            invisibleWall2.SetActive(true);
            bossScript.NewLocation();
        }
        else if(triggerNumber == 4)
        {
            triggerNumber = 5;
            invisibleWall2.SetActive(false);
            invisibleWall3.SetActive(true);
            bossScript.NewLocation();
        }
        else if(triggerNumber == 5)
        {
            triggerNumber = 6;
            invisibleWall3.SetActive(false);
            invisibleWall4.SetActive(true);
            bossScript.NewLocation();
            StopCoroutine(coroutine);
            coroutine = Part6();
            StartCoroutine(coroutine);
        }
    }

    public IEnumerator StartTutorial()
    {
        tutorialText.text = "Welcome to (Game Name)";
        yield return new WaitForSeconds(3);
        tutorialText.text = "This is the tutorial";
        yield return new WaitForSeconds(3);
        tutorialText.text = "";
    }

    public IEnumerator Part1()
    { 
        lamp1.SetActive(true);
        yield return new WaitForSeconds(2);
        tutorialText.text = "In this game you need to escape";
        yield return new WaitForSeconds(4);
        tutorialText.text = "For each level there is one specific escape";
        yield return new WaitForSeconds(4);
        tutorialText.text = "This is the first escape you're going to encounter";
        yield return new WaitForSeconds(4);
        tutorialText.text = "Try picking up the phone and energy box (Left mouse button)";
    }
    public IEnumerator Part2()
    {
        tutorialText.text = "Great!";
        yield return new WaitForSeconds(3);
        tutorialText.text = "Now use them on the generator (Left mouse button)";
    }
    public IEnumerator Part3()
    {
        tutorialText.text = "Good job!";
        yield return new WaitForSeconds(3);
        tutorialText.text = "For this escape you need to wait for the generator to start";
        yield return new WaitForSeconds(6);
        tutorialText.text = "Some escapes are based on other mechanics";
        yield return new WaitForSeconds(5);
        tutorialText.text = "When you start a level you get the information you need";
        yield return new WaitForSeconds(5);
        generator1.GetComponent<GeneratorScript>().phoneRingingSound.Play();
        yield return new WaitForSeconds(2);
        tutorialText.text = "This is the sound that the phone is ready to use";
        yield return new WaitForSeconds(4);
        tutorialText.text = "You finish the level by clicking on the generator again";
        generator1.GetComponent<GeneratorScript>().readyForTutorial = true;
    }
    public IEnumerator Part4()
    {
        lamp1.SetActive(false);
        tutorialText.text = "Now we go to the next area";
        yield return new WaitForSeconds(4);
        tutorialText.text = "Go back the way you came from";
        door1.SetActive(false);
    }
    public IEnumerator Part5()
    {
        door3.SetActive(true);
        tutorialText.text = "This is the tutorial boss";
        yield return new WaitForSeconds(4);
        tutorialText.text = "Your alerting radius is based on the way you move";
        yield return new WaitForSeconds(5);
        tutorialText.text = "Its Displayed at the bottom of the screen";
        yield return new WaitForSeconds(4);
        tutorialText.text = "When you run you have a very big radius where the boss can hear you";
        yield return new WaitForSeconds(6);
        tutorialText.text = "When you walk normally its a little bit smaller";
        yield return new WaitForSeconds(5);
        tutorialText.text = "When you crouch and walk or stand still its a lot smaller";
        yield return new WaitForSeconds(6);
        tutorialText.text = "And when you crouch and stand still its the smallest";
        yield return new WaitForSeconds(5);
        tutorialText.text = "Run = Left shift and Crouch = Left Ctrl";
        yield return new WaitForSeconds(4);
        tutorialText.text = "When the boss hears you, you hear this sound";
        yield return new WaitForSeconds(4);
        bossScript.alertingSound.Play();
        yield return new WaitForSeconds(2);
        tutorialText.text = "When the boss follows you there is music playing";
        yield return new WaitForSeconds(5);
        tutorialText.text = "Now run for the boss";
        door2.SetActive(false);
        yield return new WaitForSeconds(3);
        bossScript.alertingSound.Play();
        yield return new WaitForSeconds(2);
        bossScript.GetComponent<NavMeshAgent>().speed = 4;
        bossScript.NewLocation();
    }
    public IEnumerator Part6()
    {
        yield return new WaitForSeconds(2);
        tutorialText.text = "Oh no, it looks like your cornered";
        yield return new WaitForSeconds(4);
        tutorialText.text = "But you can survive";
        yield return new WaitForSeconds(3);
        tutorialText.text = "In the left bottom corner you have your ability";
        yield return new WaitForSeconds(5);
        tutorialText.text = "You can choose your ability in the main menu";
        yield return new WaitForSeconds(5);
        tutorialText.text = "The stun ability is selected in this tutorial";
        yield return new WaitForSeconds(5);
        tutorialText.text = "Some ability's have a cooldown, some are always active";
        yield return new WaitForSeconds(5);
        tutorialText.text = "You hear this sound when a cooldown is finished";
        yield return new WaitForSeconds(3);
        abilityReadySound.Play();
        yield return new WaitForSeconds(2);
        tutorialText.text = "What each ability does is displayed in the main menu";
        yield return new WaitForSeconds(5);
        tutorialText.text = "With stun active when the boss hits you you get a skill check";
        yield return new WaitForSeconds(5);
        tutorialText.text = "A fast timing based event where you need to press the ability button at the right time";
        yield return new WaitForSeconds(6);
        tutorialText.text = "With ability's with cooldown the ability button = E";
        yield return new WaitForSeconds(5);
        tutorialText.text = "With passive ability's you dont need the button";
        yield return new WaitForSeconds(5);
        tutorialText.text = "Now lets test your skills";
        yield return new WaitForSeconds(3);
        invisibleWall4.SetActive(false);
        bossScript.setPlayerLocAsLoc = true;
    }

    public void DoSkillCheck()
    {
        bossScript.StandStill();
        skillCheckObj.SetActive(true);
        skillCheckBackground.SetActive(true);
        goSkillCheckBool = true;
    }

    when failed load menu
}
