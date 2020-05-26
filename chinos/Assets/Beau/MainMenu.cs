using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuScreen, chooseAbilityScreen;
    public GameObject[] backGrounds;

    public AudioSource menuMusic, buttonHoverSound, buttonClickSound;

    private void Start()
    {
        RandomBackGround();
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
        buttonClickSound.Play();
        SceneManager.LoadScene("Game");
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
}
