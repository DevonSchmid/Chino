using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelector : MonoBehaviour
{
    static public int abilitySelect = 1;
    public AudioSource buttonClick, buttonError;

    public void SelectAbilityOne()
    {
        abilitySelect = 1;
        buttonClick.Play();
    }

    public void SelectAbilityComingSoon()
    {
        print("coming soon");
        buttonError.Play();
    }
}
