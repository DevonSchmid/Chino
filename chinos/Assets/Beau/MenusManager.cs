using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class MenusManager : MonoBehaviour
{
    public GameObject menuPanel, optionsPanel, graphicsDropdown, windowDropdown;

    private void Update()
    {
        SetMenuPanel();
    }

    void SetMenuPanel()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(menuPanel.activeSelf == false && optionsPanel.activeSelf == false)
            {
                menuPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
            else if (menuPanel.activeSelf == true && optionsPanel.activeSelf == false)
            {
                Time.timeScale = 1f;
                menuPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if(menuPanel.activeSelf == false && optionsPanel.activeSelf == true)
            {
                optionsPanel.SetActive(false);
                menuPanel.SetActive(true);
            }
        }
    }

    public void SetMenuPanelInactve()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menuPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void BackToMenuPanel()
    {
        menuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void SetOptionsPanelActive()
    {
        menuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("QuitGame");
    }

    public void ChangeGraphics()
    {
        if(graphicsDropdown.GetComponent<TMPro.TMP_Dropdown>().value == 0)
        {
            print("Low");
            QualitySettings.SetQualityLevel(0, true);
        }
        if (graphicsDropdown.GetComponent<TMPro.TMP_Dropdown>().value == 1)
        {
            print("Medium");
            QualitySettings.SetQualityLevel(1, true);
        }
        if (graphicsDropdown.GetComponent<TMPro.TMP_Dropdown>().value == 2)
        {
            print("High");
            QualitySettings.SetQualityLevel(2, true);
        }
    }
    public void ChangeWindow()
    {
        if(windowDropdown.GetComponent<TMPro.TMP_Dropdown>().value == 0)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        if (windowDropdown.GetComponent<TMPro.TMP_Dropdown>().value == 1)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        if (windowDropdown.GetComponent<TMPro.TMP_Dropdown>().value == 2)
        {
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        }
    }
}
