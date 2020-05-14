using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuScreen, chooseAbilityScreen;
    public GameObject[] backGrounds;

    public AudioSource menuMusic;

    private void Start()
    {
        RandomBackGround();
    }

    void RandomBackGround()
    {
        int randomBackgroundNumber = Random.Range(0, backGrounds.Length);
        backGrounds[randomBackgroundNumber].SetActive(true);
    }

    public void MuteMenuMusic()
    {
        if(menuMusic.isPlaying == true)
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
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        mainMenuScreen.SetActive(true);
        chooseAbilityScreen.SetActive(false);
    }

    public void GoToOptions()
    {
        mainMenuScreen.SetActive(false);
    }

    public void GoChooseAbilityScreen()
    {
        mainMenuScreen.SetActive(false);
        chooseAbilityScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Quitting");
    }
}
