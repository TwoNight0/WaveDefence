using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Archer : Unit
{
    Unit_Archer()
    {
        this.attackDamage = 10.0f;
        this.attackSpeed = 1.0f; //기본 발사 속도
        this.range = 15f; //기본 근접
        this.magicDamage = 0.0f;
        this.skillDamage = 0.0f;
        this.critical = 0.0f;
        this.skillCoolDown = 0.0f;
        this.moveSpeed = 3.0f;
    }

    /// <summary>
    /// 만약 추가적으로 다른게 필요하면 추가 수정해서 3x3 버튼을 수정할 것 ex) 다음이 필요할시 
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

        //타깃 업데이트
        //InvokeRepeating("TargetUpdate", 0f, 0.1f);
        
        firePoint = GameObject.Find("FirePoint").transform;

        allowCollider = GameManager.instance.allowMoveObj.GetComponent<Collider>();

        anim = GetComponent<Animator>();

        btn3x3 = GameManager.instance.btn3x3Obj.GetComponent<Btn3x3>();

        //characterType에 해당하는 총알가져오기
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
