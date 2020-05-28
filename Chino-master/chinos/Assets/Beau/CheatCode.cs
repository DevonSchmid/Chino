using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheatCode : MonoBehaviour
{
    public GameObject inputPanel, inputField;

    public string code1 = "show it";
    public string code2 = "skip tutorial";

    static public bool showItActivated;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            inputPanel.SetActive(true);
        }
    }
    
    public void EndText()
    {
        if (inputField.GetComponent<TMP_InputField>().text == code1)
        {
            showItActivated = true;
            inputField.GetComponent<TMP_InputField>().text = "";
            inputPanel.SetActive(false);
        }
        else if (inputField.GetComponent<TMP_InputField>().text == code2)
        {
            if(LevelManager.levelNumber == 1)
            {
                LevelManager.levelNumber = 2;
                inputField.GetComponent<TMP_InputField>().text = "";
                inputPanel.SetActive(false);
            }
        }
        else
        {
            inputField.GetComponent<TMP_InputField>().text = "";
        }
    }
}
