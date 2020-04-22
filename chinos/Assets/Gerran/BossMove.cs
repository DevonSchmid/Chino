using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public int bossSpeed;
    public GameObject player;
    public void Start()
    {
        print(bossSpeed);
    }
    public void Update()
    {
        bossSpeed = player.GetComponent<PlayerAbility>().bossSpeedSetTo;
    }
}
