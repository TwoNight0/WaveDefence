using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;

    public float startSpeed = 5f;
    public float speed = 5f;
    public float explosionRadius = 0f;
    public float damagePhysic;
    public float damageMagic;
    public float rotationSpeed = 60f;

    public string characterType;

    private Rigidbody rb;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        InvokeRepeating("TurnTotarget", 0f, 0.8f);
    }

    private void OnDisable()
    {
        CancelInvoke("TurnTotarget");
    }

    void Update()
    {
        MoveToTarget();
    }

    /// <summary>
    /// Ÿ�������� �̵���
    /// </summary>
    /// <param name="_target"></param>
    public void MoveToTarget()
    {
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.GetComponent<Collider>().bounds.center - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// Ÿ�꼳��
    /// </summary>
    /// <param name="_target"></param>
    public void chaseTarget(Transform _target)
    {
        target = _target;
        //Debug.Log("target on");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //���Ϳ� ������ ��ȯ
            Debug.Log("�浹!");
            MngBullet.instance.ReturnBullet(characterType, this.gameObject);
            Damage(collision.transform);
            
        }
    }

    private void TurnTotarget()
    {
        if (target != null)
        {
            // Ÿ�� ���� ���� ���
            Vector3 directionToTarget = target.position - transform.position;
            //Debug.Log(directionToTarget);

            // Ÿ�� ������ ȸ�� ���� ���
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            transform.rotation = targetRotation;
        }
    }

    void Explode()
    {
        //�������� �ݶ��̴��� üũ
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                
                Damage(collider.transform);
            }
        }
    }

    /// <summary>
    /// target�� ad, ap�� �����Ű�� Ÿ�곻�� ������ ����ؼ� �������� ��
    /// </summary>
    /// <param name="_enemy">target</param>
    void Damage(Transform _enemy)
    {
        Enemy enemy = _enemy.GetComponent<Enemy>();
        if (enemy != null)
        {
            //������ �ֱ�
            //Debug.Log("������");
            enemy.TakeDamage(damagePhysic, damageMagic);
        }
        //������ �ְ� �״°Ŵ� enmey �� ���� 

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
