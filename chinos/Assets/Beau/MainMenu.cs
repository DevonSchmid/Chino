using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuScreen, optionsScreen, chooseAbilityScreen;

    private void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        mainMenuScreen.SetActive(true);
        optionsScreen.SetActive(false);
        chooseAbilityScreen.SetActive(false);
    }

    public void GoToOptions()
    {
        mainMenuScreen.SetActive(false);
        optionsScreen.SetActive(true);
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
