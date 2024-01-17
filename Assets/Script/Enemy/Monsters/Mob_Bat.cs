using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mob_Bat : Enemy
{
    Mob_Bat()
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

        anim = GetComponent<Animator>();

        //HpBar ��Ʈ��
        this.hpBarObj = GameObject.Find("HpCanvas");
        hpBar = hpBarObj.GetComponent<RectTransform>();
        hpSlider = hpBarObj.transform.GetChild(0).GetComponent<Slider>();

        //Debug.Log("slider" + hpSlider);
        //hp Bar �ؽ�Ʈ �������� -> ���� ������ �����̴��� �ٱ��
        this.rotateHpbar(hpBar, new Vector3(-70,0,0));
        //��ġ������ �����ؾ��ҵ�?

        waypointindex++;

        //Ÿ������(�ɾ ��ǥ)
        target = GameManager.instance.waypoints[waypointindex];

        transform.LookAt(target);

        btn3x3 = GameManager.instance.btn3x3Obj.GetComponent<Btn3x3>();
        //Debug.Log(hpBar);

        StartCoroutine(AnimDizzy(8));

    }

    // Update is called once per frame
    void Update()
    { 
        MoveToTarget(this.transform , speed);

    }
}
