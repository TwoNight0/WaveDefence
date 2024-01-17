using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;

public class Unit : MonoBehaviour
{

    protected Btn3x3 btn3x3;
    protected Transform target;
    private Enemy targetEnemy;
    //public Transform partToRotate;
    protected new string name = "temp";

    public string characterType;

    [Header("���� ����")]
    protected float attackDamage = 10.0f;
    protected float attackSpeed = 1.0f; //�⺻ �߻� �ӵ�
    protected float range = 15f; //�⺻ ����
    protected float magicDamage = 0.0f;
    protected float skillDamage = 0.0f;
    protected float critical = 0.0f;
    protected float skillCoolDown = 0.0f;
    protected float moveSpeed = 3.0f;

    protected float fireCountdown = 1f;

    protected int mana = 3;

    protected int unitClass;

    public bool canMove = true;
    public bool attackmode = true;

    [Header("����Ƽ ����")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    //�̺κ� ���߿� Bullet ��ũ��Ʈ�� ��ü�ؾ��Ҽ�������
    protected GameObject bulletPrefab;
    protected Transform firePoint;


    protected Animator anim;
    protected Collider allowCollider;

    Ray ray;
    RaycastHit hit;

    /// <summary>
    /// �̰� ���߿� �������� �Ѱ���߰ڴ�
    /// </summary>
    protected virtual void OnMouseDown()
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
    /// ��ȯ�̵Ǹ�, ���콺��ġ�� ��������� �̵� �ƴ϶�� ����, �̰� �������� Canmove Ʈ���Ű��
    /// </summary>
    public void UnitMove()
    {
        if(canMove == true)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == allowCollider && Input.GetMouseButtonDown(0))
                {

                    //Debug.Log("dd");
                    transform.LookAt(hit.point);

                    //���� �ִϸ��̼� ���
                    anim.SetBool("isMove", true);
                    float distance = Vector3.Distance(transform.position, hit.point);
                    float speed = distance / moveSpeed;

                    transform.DOMove(hit.point, speed).SetEase(Ease.Linear);

                }
            }
        }
    }

    public void UnitStop()
    {
        if(canMove == true && Vector3.Distance(this.transform.position, target.position) <= 0.4f)
        {
            anim.SetBool("isMove", false);
        }
    }

    /// <summary>
    /// ����
    /// </summary>
    public void Attack_Shoot()
    {
        fireCountdown += Time.deltaTime;
        if (attackmode && fireCountdown >= attackSpeed && target != null)
        {
            //Vector3 directionToTarget = target.position - transform.position;
            //transform.LookAt(target);
            transform.DOLookAt(target.position, 0.5f);
            //Debug.Log("������� ����");
            //characterType�� �ش��ϴ� �Ѿ˰�������
            GameObject bulletObj = MngBullet.instance.GetBullet(characterType);
            fireCountdown = 0;
            if(firePoint != null)
            {
                bulletObj.transform.position = firePoint.position;
            }

            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.damagePhysic = attackDamage;
            bullet.damageMagic = magicDamage;
            bullet.target = target;

            anim.SetBool("IsAttack", true);

        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// bullet�� �Ⱦ��� ĳ����
    /// </summary>
    public void Attack_Melee()
    {
        if(target != null)
        {
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeDamage(attackDamage, magicDamage);
        }
    }

    public void GatherResource(int kind)
    {
        switch (kind)
        {
            //Ore
            case 0:

                break;
            //Wood
            case 1:

                break;
        }
    }

    /// <summary>
    /// ���׷��̵� ��ҷ� �̵� 1�̾��������� 1, 2�� �������� 3
    /// </summary>
    public void Combinate()
    {

    }

    /// <summary>
    /// ���ļ� ���� ĳ���̸� ������
    /// </summary>
    public void DisAssemble()
    {

    }

    /// <summary>
    /// ��ġ����
    /// </summary>
    public void Anchor() {
        canMove = false;
    }

    /// <summary>
    /// Ÿ���� �ٲٴ� ��Ŀ����
    /// </summary>
    public void TargetUpdate()
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
            anim.SetBool("IsAttack", false);
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
