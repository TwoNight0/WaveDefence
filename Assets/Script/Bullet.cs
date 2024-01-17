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
    /// 타깃쪽으로 이동함
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
    /// 타깃설정
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
            //몬스터에 닿으면 반환
            Debug.Log("충돌!");
            MngBullet.instance.ReturnBullet(characterType, this.gameObject);
            Damage(collision.transform);
            
        }
    }

    private void TurnTotarget()
    {
        if (target != null)
        {
            // 타겟 방향 벡터 계산
            Vector3 directionToTarget = target.position - transform.position;
            //Debug.Log(directionToTarget);

            // 타겟 방향의 회전 각도 계산
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            transform.rotation = targetRotation;
        }
    }

    void Explode()
    {
        //원형으로 콜라이더를 체크
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
    /// target에 ad, ap를 적용시키면 타깃내의 방어력을 고려해서 데미지가 들어감
    /// </summary>
    /// <param name="_enemy">target</param>
    void Damage(Transform _enemy)
    {
        Enemy enemy = _enemy.GetComponent<Enemy>();
        if (enemy != null)
        {
            //데미지 넣기
            //Debug.Log("딜넣음");
            enemy.TakeDamage(damagePhysic, damageMagic);
        }
        //데미지 넣고 죽는거는 enmey 에 있음 

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
