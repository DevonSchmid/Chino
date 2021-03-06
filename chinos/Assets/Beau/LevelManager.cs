﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    static public int levelNumber = 1;
    public TextMeshProUGUI LevelText;
    public GameObject congretsScreen;

    private void Update()
    {
        LoadLevelNumber();
    }

    public void LoadLevelNumber()
    {
        if(levelNumber == 0)
        {
            levelNumber = 1;
        }
        if (levelNumber == 1)
        {
            LevelText.text = "Tutorial";
        }
        else if (levelNumber == 2)
        {
            LevelText.text = "Level 1";
        }
        else if (levelNumber == 3)
        {
            LevelText.text = "Level 2";
        }
        else if (levelNumber == 4)
        {
            LevelText.text = "Level 3";
        }
        else if (levelNumber == 5)
        {
            LevelText.text = "Level 4";
        }
        else if(levelNumber == 6)
        {
            congretsScreen.SetActive(true);
        }
    }
}
