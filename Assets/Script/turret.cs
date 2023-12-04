using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;
    public Transform partToRotate;

    [Header("포탑 설정")]
    public float range = 15f;
    public float fireRate = 1.0f;
    private float fireCountdown = 0f;

    [Header("유니티 설정")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    //이부분 나중에 Bullet 스크립트로 대체해야할수도있음
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("TargetUpdate", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;

        //쿼터니언을 구하고
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        //오일러로 변환
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    public void Shoot()
    {
        GameObject bullet_Obj = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bullet_Obj.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.chaseTarget(target);
        }
    }


    void TargetUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject newarestEnemy = null;
        foreach ( GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                //최단거리를 적까지의 거리로 할당
                shortestDistance = distanceToEnemy;
                newarestEnemy = enemy;
            }
        }

        // 사거리안에 있으면서 적도 찾았을때
        if(newarestEnemy != null && shortestDistance <= range) { 
            target = newarestEnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
        }
        else//사거리 밖이면 타깃을 초기화
        {
            target = null;
        }


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}
