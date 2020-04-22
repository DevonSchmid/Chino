using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbility : MonoBehaviour
{
    public Image cooldownImage;
    public Vector2 endDest;
    bool used = false;
    public float timer;
    public float cooldownTime;
    public int bossSpeedSetTo;
    public int bossSpeedCheck;
    public GameObject boss;

    private void Start()
    {
        bossSpeedCheck = boss.GetComponent<BossMove>().bossSpeed;
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
                cooldownImage.rectTransform.sizeDelta = new Vector2(0, 100);
                bossSpeedSetTo = 0;
                used = true;
            }

        }
        if (cooldownImage.rectTransform.sizeDelta.y <= -0.00001)
        {
             cooldownImage.rectTransform.sizeDelta = new Vector2(0, 0);
             print("test");
             used = false;
             bossSpeedSetTo = bossSpeedCheck;
        }
        if (used == true)
        {
            cooldownImage.rectTransform.sizeDelta -= new Vector2(0, cooldownTime * Time.deltaTime);
        }
    }
    
}
