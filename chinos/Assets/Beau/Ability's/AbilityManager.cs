using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public GameObject[] abilitys;

    private void Start()
    {
        StunAbilitySetActive();
    }

    public void StunAbilitySetActive()
    {
        abilitys[0].SetActive(true);
    }
}
