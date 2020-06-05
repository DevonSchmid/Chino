using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbilityManager : MonoBehaviour
{
    public int abilityNumber;
    public GameObject[] abilitys;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name != "Tutorial")
        {
            abilityNumber = AbilitySelector.abilitySelect;
            abilitys[abilityNumber - 1].SetActive(true);
        }
        else if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            abilitys[0].SetActive(true);
        }
    }
}
