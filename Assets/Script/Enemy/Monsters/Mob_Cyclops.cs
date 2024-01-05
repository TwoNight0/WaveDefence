using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Cyclops : Enemy
{
    Mob_Cyclops()
    {
        maxHp = 100f;
        startSpeed = 10.0f;

        //����
        reward = 10;

    }



    // Start is called before the first frame update
    void Start()
    {
        nowHp = maxHp;
        speed = startSpeed;

        //HpBar ��Ʈ��
        this.hpBarObj = GameObject.Find("HpCanvas");
        hpBar = hpBarObj.GetComponent<RectTransform>();

        //hp Bar �ؽ�Ʈ �������� -> ���� ������ �����̴��� �ٱ��


        waypointindex++;

        //Ÿ������(�ɾ ��ǥ)
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
