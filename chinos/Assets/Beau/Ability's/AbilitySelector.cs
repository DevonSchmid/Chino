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

    public void SelectAbilityOne()
    {
        abilitySelect = 1;
        buttonClick.Play();
        selected.text = "Stun Selected";
    }
    public void SelectAbilityTwo()
    {
        abilitySelect = 2;
        buttonClick.Play();
        selected.text = "Small Radius Selected";
    }

    public void SelectAbilityComingSoon()
    {
        print("coming soon");
        buttonError.Play();
    }
}
