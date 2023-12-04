using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;
    public Transform partToRotate;

    [Header("��ž ����")]
    public float range = 15f;
    public float fireRate = 1.0f;
    private float fireCountdown = 0f;

    [Header("����Ƽ ����")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;

    //�̺κ� ���߿� Bullet ��ũ��Ʈ�� ��ü�ؾ��Ҽ�������
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

        //���ʹϾ��� ���ϰ�
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        //���Ϸ��� ��ȯ
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
                //�ִܰŸ��� �������� �Ÿ��� �Ҵ�
                shortestDistance = distanceToEnemy;
                newarestEnemy = enemy;
            }
        }

        // ��Ÿ��ȿ� �����鼭 ���� ã������
        if(newarestEnemy != null && shortestDistance <= range) { 
            target = newarestEnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
        }
        else//��Ÿ� ���̸� Ÿ���� �ʱ�ȭ
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
