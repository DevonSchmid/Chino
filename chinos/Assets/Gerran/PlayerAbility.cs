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
    public int bossSpeed;
    public int bossSpeedCheck;
    public BossMove bossMoveScript;
    public void Start()
    {
        
    }

    public void Update()
    {
        Ability();
        bossSpeed = GetComponent<BossMove>().bossSpeed;
    }

    public void Ability()
    {
        if (used == false)
        {
            bossSpeedCheck = bossSpeed;

            if (Input.GetButtonDown("Ability"))
            {
                cooldownImage.rectTransform.sizeDelta = new Vector2(0, 100);
                used = true;
                bossSpeed = 0;

            }
        }
        if (used == true)
        {
            timer += Time.deltaTime;
            cooldownImage.rectTransform.sizeDelta -= new Vector2(0, cooldownTime * Time.deltaTime);
        }
        if (cooldownImage.rectTransform.sizeDelta.y <= 0)
        {
            print(timer);
            used = false;
            bossSpeed = bossSpeedCheck;
        }
    }
}
