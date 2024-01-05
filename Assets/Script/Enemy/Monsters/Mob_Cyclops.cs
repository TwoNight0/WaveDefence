using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Cyclops : Enemy
{
    Mob_Cyclops()
    {
        maxHp = 100f;
        startSpeed = 10.0f;

        //보상
        reward = 10;

    }



    // Start is called before the first frame update
    void Start()
    {
        nowHp = maxHp;
        speed = startSpeed;

        //HpBar 컨트롤
        this.hpBarObj = GameObject.Find("HpCanvas");
        hpBar = hpBarObj.GetComponent<RectTransform>();

        //hp Bar 텍스트 가져오기 -> 피해 입으면 슬라이더랑 다깍기


        waypointindex++;

        //타겟지정(걸어갈 목표)
        target = GameManager.instance.waypoints[waypointindex];

        transform.LookAt(target);


        Debug.Log(hpBar);

        //this.rotateHpbar(hpBar);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget(this.transform, speed);
    }
}
