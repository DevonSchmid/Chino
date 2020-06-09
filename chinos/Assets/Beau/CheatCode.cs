using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheatCode : MonoBehaviour
{
    public GameObject inputPanel, inputField, placeholder;
    public string placeholderMain;

    public string[] code;

    static public bool showItActivated;

    static public bool stopBoss;

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
        else if(inputField.GetComponent<TMP_InputField>().text == code[3])
        {
            stopBoss = !stopBoss;
            inputField.GetComponent<TMP_InputField>().text = "";
            inputPanel.SetActive(false);
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
                LevelManager.levelNumber = 1;
                inputPanel.SetActive(false);
            }
            else if(inputField.GetComponent<TMP_InputField>().text == "1")
            {
                placeholder.GetComponent<TextMeshProUGUI>().text = placeholderMain;
                inputField.GetComponent<TMP_InputField>().text = "";
                LevelManager.levelNumber = 2;
                inputPanel.SetActive(false);
            }
            else if(inputField.GetComponent<TMP_InputField>().text == "2")
            {
                placeholder.GetComponent<TextMeshProUGUI>().text = placeholderMain;
                inputField.GetComponent<TMP_InputField>().text = "";
                LevelManager.levelNumber = 3;
                inputPanel.SetActive(false);
            }
            else if (inputField.GetComponent<TMP_InputField>().text == "3")
            {
                placeholder.GetComponent<TextMeshProUGUI>().text = placeholderMain;
                inputField.GetComponent<TMP_InputField>().text = "";
                LevelManager.levelNumber = 4;
                inputPanel.SetActive(false);
            }
            else if (inputField.GetComponent<TMP_InputField>().text == "4")
            {
                placeholder.GetComponent<TextMeshProUGUI>().text = placeholderMain;
                inputField.GetComponent<TMP_InputField>().text = "";
                LevelManager.levelNumber = 5;
                inputPanel.SetActive(false);
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
