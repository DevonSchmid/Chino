using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilOld : MonoBehaviour
{
    public Image cooldownImage;
    public Vector2 endDest;
    bool used = false;
    public float perTransform;
    float standartBossSpeed;
    public GameObject bossGameobject;

    private void Start()
    {
        bossGameobject = GameObject.Find("Boss");
        standartBossSpeed = bossGameobject.GetComponent<BossMovement>().bossSpeed;

    }
    public void Update()
    {
        Ability();
    }

    public void Ability()
    {
        if (used == false)
        {
            if (Input.GetButtonDown("Ability"))
            {
                print("Pressed F");
                cooldownImage.rectTransform.sizeDelta = new Vector2(0, 100);
                bossGameobject.GetComponent<BossMovement>().bossAgent.speed = 0;
                used = true;
            }

        }
        if (cooldownImage.rectTransform.sizeDelta.y <= -0.00001)
        {
            used = false;
            cooldownImage.rectTransform.sizeDelta = new Vector2(0, 0);
            print("test");
            
        }
        if (cooldownImage.rectTransform.sizeDelta.y >= 0.00001)
        {
            cooldownImage.rectTransform.sizeDelta -= new Vector2(0, perTransform * Time.deltaTime);
        }
    }
    
}
