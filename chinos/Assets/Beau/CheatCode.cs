﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheatCode : MonoBehaviour
{
    public GameObject inputPanel, inputField, placeholder;
    public string placeholderMain;

    public string[] code;

    public string code1 = "show it";
    public string code2 = "skip tutorial";
    public string code3 = "load level";

    static public bool showItActivated;

    private void Start()
    {
        placeholderMain = placeholder.GetComponent<TextMeshProUGUI>().text;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            inputPanel.SetActive(!inputPanel.activeSelf);
        }
    }
    
    public void EndText()
    {
        if (inputField.GetComponent<TMP_InputField>().text == code[0])
        {
            showItActivated = true;
            inputField.GetComponent<TMP_InputField>().text = "";
            inputPanel.SetActive(false);
        }
        else if (inputField.GetComponent<TMP_InputField>().text == code[1])
        {
            if(LevelManager.levelNumber == 1)
            {
                LevelManager.levelNumber = 2;
                inputField.GetComponent<TMP_InputField>().text = "";
                inputPanel.SetActive(false);
            }
        }
        else if (inputField.GetComponent<TMP_InputField>().text == code[2])
        {
            placeholder.GetComponent<TextMeshProUGUI>().text = "Which level?";
            inputField.GetComponent<TMP_InputField>().text = "";
        }
        else if (placeholder.GetComponent<TextMeshProUGUI>().text == "Which level?")
        {
            if(inputField.GetComponent<TMP_InputField>().text == "tutorial")
            {
                placeholder.GetComponent<TextMeshProUGUI>().text = placeholderMain;
                inputField.GetComponent<TMP_InputField>().text = "";
                print("Load level Tutorial");
                LevelManager.levelNumber = 1;
            }
            else if(inputField.GetComponent<TMP_InputField>().text == "1")
            {
                placeholder.GetComponent<TextMeshProUGUI>().text = placeholderMain;
                inputField.GetComponent<TMP_InputField>().text = "";
                print("Load level 1");
                LevelManager.levelNumber = 2;
            }
            else if(inputField.GetComponent<TMP_InputField>().text == "2")
            {
                placeholder.GetComponent<TextMeshProUGUI>().text = placeholderMain;
                inputField.GetComponent<TMP_InputField>().text = "";
                print("Load level 2");
                LevelManager.levelNumber = 3;
            }
            else
            {
                inputField.GetComponent<TMP_InputField>().text = "";
            }
        }
        else
        {
            inputField.GetComponent<TMP_InputField>().text = "";
        }
    }
}
