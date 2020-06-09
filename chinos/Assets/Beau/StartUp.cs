using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUp : MonoBehaviour
{
    private void Start()
    {
        LevelManager.levelNumber = PlayerPrefs.GetInt("CurrentLevel");
        AbilitySelector.abilitySelect = PlayerPrefs.GetInt("CurrentAbil");

        SceneManager.LoadScene("MainMenu");
    }
}
