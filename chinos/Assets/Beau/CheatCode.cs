using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheatCode : MonoBehaviour
{
    public GameObject inputPanel, inputField;

    public string code = "show it";

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
        if (inputField.GetComponent<TMP_InputField>().text == code)
        {
            showItActivated = true;
        }
    }
}
