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

    [Header("���� ����")]
    protected float attackDamage = 10.0f;
    protected float attackSpeed = 1.0f; //�⺻ �߻� �ӵ�
    protected float range = 15f; //�⺻ ����
    protected float magicDamage = 0.0f;
    protected float skillDamage = 0.0f;
    protected float critical = 0.0f;
    protected float skillCoolDown = 0.0f;
    protected float moveSpeed = 3.0f;
    
    protected int mana = 3;

    protected int unitClass;

    public bool autoMode = true;

    [Header("����Ƽ ����")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    //�̺κ� ���߿� Bullet ��ũ��Ʈ�� ��ü�ؾ��Ҽ�������
    protected GameObject bulletPrefab;
    protected Transform firePoint;

    private Collider allowCollider;

    Ray ray;
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TargetUpdate", 0f, 0.5f);
        //�׽�Ʈ��

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


        Debug.Log("ĳ����");

        GameManager.instance.btn_3x3_state = GameManager.Btn_3x3_state.CLICK_Unit;

        #region btn 3x3 Setting
        //0 Q  Move : �̵�
        btn3x3.BtnSetting(0, 0, 0, "IMG_Character/Move", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(0);

        //1 W Attack : �ڵ� ���� ���󰡸鼭 ����
        btn3x3.BtnSetting(1, 0, 0, "IMG_Character/Attack", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(1);

        //2 E Anchor : ���� ,��ġ ���, �������� �����鼭 ��Ÿ� �� ����
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

        //7 X Combinate : ���� ����̵� �� ���� ���մ뿡�� ���׷��̵�
        btn3x3.BtnSetting(7, 0, 0, "IMG_Character/Combinate", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(7);

        //8 C Disassemble : ���� , ĳ���� ��ġ�� 3������ ���� 
        btn3x3.BtnSetting(8, 0, 0, "IMG_Character/Disassemble", "IMG_ETC/None");
        btn3x3.ChangeBtnPriceTextNone(8);
        #endregion

        GameManager.instance.playerStats.UpdateUnitUI(name, attackDamage, attackSpeed, range, 
            magicDamage, mana, skillDamage, critical, skillCoolDown, moveSpeed);

    }

    /// <summary>
    /// ��ȯ�̵Ǹ�, ���콺��ġ�� ��������� �̵� �ƴ϶�� ����
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
    /// Ÿ���� �ٲٴ� ��Ŀ����
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
                //�ִܰŸ��� �������� �Ÿ��� �Ҵ�
                shortestDistance = distanceToEnemy;
                newarestEnemy = enemy;
            }
        }

        // ��Ÿ��ȿ� �����鼭 ���� ã������
        if (newarestEnemy != null && shortestDistance <= range)
        {
            target = newarestEnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
        }
        else//��Ÿ� ���̸� Ÿ���� �ʱ�ȭ
        {
            target = null;
        }

    }

    /// <summary>
    /// ������ �����Ϳ����� �ӽ÷� ��������
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

    
}
