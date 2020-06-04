using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuScreen, chooseAbilityScreen;
    public GameObject[] backGrounds;
    public TextMeshProUGUI startButtonText;

    public AudioSource menuMusic, buttonHoverSound, buttonClickSound;

    bool canClick = false;
    public Color normalWhite, fadedWhite;
    private void Start()
    {
        RandomBackGround();

        startButtonText.color = fadedWhite;
        StartCoroutine(StartButtonReady());
    }

    public void RandomBackGround()
    {
        backGrounds[0].SetActive(false); backGrounds[1].SetActive(false); backGrounds[2].SetActive(false);

        int randomBackgroundNumber = Random.Range(0, backGrounds.Length);
        backGrounds[randomBackgroundNumber].SetActive(true);
    }

    public void MuteMenuMusic()
    {
        buttonClickSound.Play();
        if (menuMusic.isPlaying == true)
        {
            menuMusic.Pause();
        }
        else
        {
            menuMusic.Play();
        }
    }

    public void StartGame()
    {
        if(canClick == true)
        {
            buttonClickSound.Play();
            if (LevelManager.levelNumber == 1)
            {
                SceneManager.LoadScene("Tutorial");
            }
            if (LevelManager.levelNumber == 2)
            {
                SceneManager.LoadScene("Level1");
            }
            if (LevelManager.levelNumber == 3)
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }

    public void BackToMenu()
    {
        buttonClickSound.Play();
        mainMenuScreen.SetActive(true);
        chooseAbilityScreen.SetActive(false);
    }

    public void GoToOptions()
    {
        buttonClickSound.Play();
        mainMenuScreen.SetActive(false);
    }

    public void GoChooseAbilityScreen()
    {
        buttonClickSound.Play();
        mainMenuScreen.SetActive(false);
        chooseAbilityScreen.SetActive(true);
    }

    public void HoverSound()
    {
        buttonHoverSound.Play();
    }

    public void QuitGame()
    {
        buttonClickSound.Play();
        Application.Quit();
        print("Quitting");
    }

    IEnumerator StartButtonReady()
    {
        print("wait to start");
        yield return new WaitForSeconds(5);
        print("ready");
        startButtonText.color = normalWhite;
        canClick = true;
    }
}
