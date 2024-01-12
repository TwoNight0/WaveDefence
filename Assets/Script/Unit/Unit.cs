using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;

public class Unit : MonoBehaviour
{
    private Btn3x3 btn3x3;
    private Transform target;
    private Enemy targetEnemy;
    //public Transform partToRotate;
    protected new string name = "temp";

    [Header("유닛 설정")]
    protected float attackDamage = 10.0f;
    protected float attackSpeed = 1.0f; //기본 발사 속도
    protected float range = 15f; //기본 근접
    protected float magicDamage = 0.0f;
    protected float skillDamage = 0.0f;
    protected float critical = 0.0f;
    protected float skillCoolDown = 0.0f;
    protected float moveSpeed = 3.0f;
    
    protected int mana = 3;

    protected int unitClass;

    public bool autoMode = true;

    [Header("유니티 설정")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    //이부분 나중에 Bullet 스크립트로 대체해야할수도있음
    protected GameObject bulletPrefab;
    protected Transform firePoint;

    private Collider allowCollider;

    Ray ray;
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TargetUpdate", 0f, 0.5f);
        //테스트용

        allowCollider = GameManager.instance.allowMoveObj.GetComponent<Collider>();
        Debug.Log("collider"+allowCollider);

        btn3x3 = GameManager.instance.btn3x3Obj.GetComponent<Btn3x3>();
    }

    // Update is called once per frame
    void Update()
    {
        UnitMove();
    }

    protected void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        Debug.Log("캐릭터");

        GameManager.instance.btn_3x3_state = GameManager.Btn_3x3_state.CLICK_Unit;

        #region btn 3x3 Setting
        //0 Q  Move : 이동
        btn3x3.BtnSetting(0, 0, 0, "IMG_Character/Move", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(0);

        //1 W Attack : 자동 공격 따라가면서 공격
        btn3x3.BtnSetting(1, 0, 0, "IMG_Character/Attack", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(1);

        //2 E Anchor : 고정 ,위치 사수, 움직이지 않으면서 사거리 안 공격
        btn3x3.BtnSetting(2, 0, 0, "IMG_Character/Anchor", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(2);

        //3 D Skill
        btn3x3.BtnSetting(3, 0, 0, "IMG_ETC/None", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(3);

        //4 Z Ultimate
        btn3x3.BtnSetting(4, 0, 0, "IMG_ETC/None", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(4);

        //5 A Gather_ore 
        btn3x3.BtnSetting(5, 0, 0, "IMG_Character/Gather_Ore", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(5);

        //6 S Gather_wood 
        btn3x3.BtnSetting(6, 0, 0, "IMG_Character/Gather_Wood", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(6);

        //7 X Combinate : 조합 대로이동 → 이후 조합대에서 업그레이드
        btn3x3.BtnSetting(7, 0, 0, "IMG_Character/Combinate", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(7);

        //8 C Disassemble : 분해 , 캐릭터 위치에 3마리로 분해 
        btn3x3.BtnSetting(8, 0, 0, "IMG_Character/Disassemble", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(8);
        #endregion

        GameManager.instance.playerStats.UpdateUnitUI(name, attackDamage, attackSpeed, range, 
            magicDamage, mana, skillDamage, critical, skillCoolDown, moveSpeed);

    }

    /// <summary>
    /// 소환이되면, 마우스위치가 장판위라면 이동 아니라면 리턴
    /// </summary>
    public void UnitMove()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,out hit))
        {
            if(hit.collider == allowCollider && Input.GetMouseButtonDown(0))
            {

                //Debug.Log("dd");
                transform.LookAt(hit.point);

                float distance = Vector3.Distance(transform.position, hit.point);
                float speed = distance / moveSpeed;
           
                transform.DOMove(hit.point, speed).SetEase(Ease.Linear);

            }
        }
    }

    public void Shoot()
    {
        GameObject bullet_Obj = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bullet_Obj.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.chaseTarget(target);
        }
    }

    /// <summary>
    /// 타겟을 바꾸는 매커니즘
    /// </summary>
    void TargetUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject newarestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                //최단거리를 적까지의 거리로 할당
                shortestDistance = distanceToEnemy;
                newarestEnemy = enemy;
            }
        }

        // 사거리안에 있으면서 적도 찾았을때
        if (newarestEnemy != null && shortestDistance <= range)
        {
            target = newarestEnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
        }
        else//사거리 밖이면 타깃을 초기화
        {
            target = null;
        }

    }

    /// <summary>
    /// 기즈모로 에디터에서만 임시로 범위보기
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

    
}
