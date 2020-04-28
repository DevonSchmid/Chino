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
        print(abilityNumber);

        if(abilityNumber == 1)
        {
            StunAbilitySetActive(); 
        }
    }

    public void StunAbilitySetActive()
    {
        abilitys[0].SetActive(true);
    }
}
