using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilitySelector : MonoBehaviour
{
    static public int abilitySelect = 1;
    public AudioSource buttonClick, buttonError;
    public TextMeshProUGUI selected;

    private void Start()
    {
        selected.text = "Stun Selected";
    }

    private void Update()
    {
        if(abilitySelect == 1)
        {
            selected.text = "Iron Head Selected";
        }
        if(abilitySelect == 2)
        {
            selected.text = "Thiefs Feet Selected";
        }
        if (abilitySelect == 3)
        {
            selected.text = "Engeneers Hands selected";
        }
        if (abilitySelect == 4)
        {
            selected.text = "Feathery feet selected";
        }
        if (abilitySelect == 5)
        {
            selected.text = "Golden sight selected";
        }

    }

    public void SelectAbilityOne()
    {
        abilitySelect = 1;
        buttonClick.Play();
    }
    public void SelectAbilityTwo()
    {
        abilitySelect = 2;
        buttonClick.Play();
    }

    public void SelectAbilityThree()
    {
        abilitySelect = 3;
        buttonClick.Play();
    }
    public void SelectAbilityfour()
    {
        abilitySelect = 4;
        buttonClick.Play();
    }
    public void SelectAbilityfive()
    {
        abilitySelect = 5;
        buttonClick.Play();
    }
    public void SelectAbilitySix()
    {
        abilitySelect = 6;
        buttonClick.Play();
    }

    public void SelectAbilityComingSoon()
    {
        print("coming soon");
        buttonError.Play();
    }
}
