using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Unit : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;
    //public Transform partToRotate;

    [Header("���� ����")]
    protected float range = 15f; //�⺻ ����
    protected float fireRate = 1.0f; //�⺻ �߻� �ӵ�
    private float fireCountdown = 0f;
    protected float moveSpeed = 3.0f;
    public bool autoMode = true;
    protected int unitClass;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        UnitMove();
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
