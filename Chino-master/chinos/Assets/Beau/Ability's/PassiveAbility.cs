using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveAbility : MonoBehaviour
{
    public GameObject abilityImageLoc;
    public Sprite abilityImage;
    public GameObject abilityImageCover;
    public virtual void Start()
    {
        abilityImageLoc.GetComponent<Image>().sprite = abilityImage;
        abilityImageCover.SetActive(false);
    }
}
