using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Unit : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;
    //public Transform partToRotate;

    [Header("유닛 설정")]
    protected float range = 15f; //기본 근접
    protected float fireRate = 1.0f; //기본 발사 속도
    private float fireCountdown = 0f;
    protected float moveSpeed = 3.0f;
    public bool autoMode = true;
    protected int unitClass;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        UnitMove();
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
