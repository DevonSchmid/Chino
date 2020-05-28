using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Abilitys : MonoBehaviour
{
    public float cooldownTimeMinPerSec;

    public GameObject abilityImageLoc;
    public Sprite abilityImage;
    public Image abilityImageCover;
    public AudioSource abilityReadySound;

    public virtual void Start()
    {
        abilityImageCover.rectTransform.sizeDelta = new Vector2(0, 100);
        abilityImageLoc.GetComponent<Image>().sprite = abilityImage;
    }

    public virtual void Update()
    {
        if (Input.GetButtonDown("Ability"))
        {
            EPressed();
        }
        AbilityTimer();
    }

    public virtual void EPressed()
    {
    }

    void AbilityTimer()
    {
        if(abilityImageCover.rectTransform.sizeDelta.y >= 0.000001)
        {
            abilityImageCover.rectTransform.sizeDelta -= new Vector2(0, cooldownTimeMinPerSec * Time.deltaTime);
        }
        if(abilityImageCover.rectTransform.sizeDelta.y <= -0.000001)
        {
            abilityImageCover.rectTransform.sizeDelta = new Vector2(0, 0);
            abilityReadySound.Play();
        }
    }
}
