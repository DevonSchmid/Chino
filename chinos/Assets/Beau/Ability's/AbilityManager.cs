using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public int abilityNumber;
    public GameObject[] abilitys;

    private void Start()
    {
        abilityNumber = AbilitySelector.abilitySelect;
        abilitys[abilityNumber - 1].SetActive(true);
    }
}
