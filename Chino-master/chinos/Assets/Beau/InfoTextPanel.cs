using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTextPanel : MonoBehaviour
{
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
