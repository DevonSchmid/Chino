using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenusManager : MonoBehaviour
{
    public GameObject playerCam, menuPanel, optionsPanel, graphicsDropdown, deathScreenObj;

    public Slider sensitivitySlider, masterVolumeSlider, musicVolumeSlider, soundVolumeSlider, notificationVolumeSlider;
    public AudioMixer mixer;

    public AudioSource buttonHoverSound, buttonClickSound;

    private void Update()
    {
        SetMenuPanel();
    }

    void SetMenuPanel()
    {
        if (Input.GetButtonDown("Cancel") && deathScreenObj.activeSelf == false)
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
        buttonClickSound.Play();
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menuPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void BackToMenuPanel()
    {
        buttonClickSound.Play();
        menuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void SetOptionsPanelActive()
    {
        buttonClickSound.Play();
        menuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        buttonClickSound.Play();
        Application.Quit();
        print("QuitGame");
    }

    public void DiedAndBackToMainMenu()
    {
        buttonClickSound.Play();
        LevelManager.levelNumber = 2;
        SceneManager.LoadScene("MainMenu");
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

    public void SensitivityChange()
    {
        buttonClickSound.Play();
        playerCam.GetComponent<PlayerCameraLook>().sensitivity = sensitivitySlider.value * 100;
        print(sensitivitySlider.value);
    }

    public void SetMasterVolume()
    {
        buttonClickSound.Play();
        mixer.SetFloat("Master Volume", Mathf.Log10(masterVolumeSlider.value) * 20);
    }

    public void SetMusicVolume()
    {
        buttonClickSound.Play();
        mixer.SetFloat("Music Volume", Mathf.Log10(musicVolumeSlider.value) * 20);
    }
    public void SetNotificationVolume()
    {
        buttonClickSound.Play();
        mixer.SetFloat("Notification Volume", Mathf.Log10(notificationVolumeSlider.value) * 20);
    }
    public void SetSoundVolume()
    {
        buttonClickSound.Play();
        mixer.SetFloat("Sound Volume", Mathf.Log10(soundVolumeSlider.value) * 20);
    }

    public void HoverSound()
    {
        buttonHoverSound.Play();
    }
}
