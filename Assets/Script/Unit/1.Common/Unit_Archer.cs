using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Archer : Unit
{
    Unit_Archer()
    {
        this.attackDamage = 10.0f;
        this.attackSpeed = 1.0f; //�⺻ �߻� �ӵ�
        this.range = 15f; //�⺻ ����
        this.magicDamage = 0.0f;
        this.skillDamage = 0.0f;
        this.critical = 0.0f;
        this.skillCoolDown = 0.0f;
        this.moveSpeed = 3.0f;
    }

    /// <summary>
    /// ���� �߰������� �ٸ��� �ʿ��ϸ� �߰� �����ؼ� 3x3 ��ư�� ������ �� ex) ������ �ʿ��ҽ� 
    /// </summary>
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(attackmode);
        characterType = "Archer";

        //Ÿ�� ������Ʈ
        //InvokeRepeating("TargetUpdate", 0f, 0.1f);
        
        firePoint = GameObject.Find("FirePoint").transform;

        allowCollider = GameManager.instance.allowMoveObj.GetComponent<Collider>();

        anim = GetComponent<Animator>();

        btn3x3 = GameManager.instance.btn3x3Obj.GetComponent<Btn3x3>();

        //characterType�� �ش��ϴ� �Ѿ˰�������
        bulletObj = MngBullet.instance.GetBullet(characterType);
    }

    // Update is called once per frame
    void Update()
    {
        TargetUpdate();
        Attack_Shoot();
     
        //UnitMove();
        //UnitStop();
    }



}
