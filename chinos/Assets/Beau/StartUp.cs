using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class StartUp : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image image;
    Color color;
    float f;

    private void Start()
    {
        StartCoroutine(LoadNextLevel());
        LevelManager.levelNumber = PlayerPrefs.GetInt("CurrentLevel");
        AbilitySelector.abilitySelect = PlayerPrefs.GetInt("CurrentAbil");
    }

    private void Update()
    {
        f += .6f * Time.deltaTime;
        color.a = f;

        image.color = color;
        text.color = color;
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}
