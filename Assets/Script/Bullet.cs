using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;

    public GameObject bulletImpactEffect;

    // Update is called once per frame
    void Update()
    {
        //이거 뜯어고쳐서 OnCollison으로한다음 tag를 Monster로 인식했을때로 바꾸자 이렇게하면 이미 몬스터도 거리르 체크하는데 총알까지 거리를 체크하는 계산을해야함

        //if (target == null)
        //{
        //    //bullet 재활용 풀로 이동
        //    gameObject.transform.parent = GameManager.instance.recyclePool.Find("Bullet_Pool");
        //    gameObject.SetActive(false);
        //    return;
        //}

        //Vector3 dir = target.position - transform.position;


        //float distanceThisFrame = speed * Time.deltaTime;

        ////프레임당 이동해야할 거리보다 타깃과의 거리가 작다면 충돌한것
        //if (dir.magnitude <= distanceThisFrame)
        //{
        //    StartCoroutine(HitTarget());
        //    return;
        //}

        //transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        //transform.LookAt(target);

    }
    public void chaseTarget(Transform _target)
    {
        target = _target;
    }



    //너무 반복됨 최적화해야함
    IEnumerator HitTarget()
    {
        Debug.Log("충돌");

        //파괴 효과
        GameObject insEffect = (GameObject)Instantiate(bulletImpactEffect, transform.position, transform.rotation);

        yield return new WaitForSeconds(2.0f);

        //bullet Effect를 재활용 풀로 이동
        insEffect.transform.parent = GameManager.instance.recyclePool.Find("Effect_Pool");
        insEffect.SetActive(false);

        //bullet을 재활용 풀로 이동
        gameObject.transform.parent = GameManager.instance.recyclePool.Find("Bullet_Pool");
        gameObject.SetActive(false);

        //target을 재활용 풀로 이동
        target.parent = GameManager.instance.recyclePool.Find("Monster_Pool");
        target.gameObject.SetActive(false);

        if(explosionRadius > 0f)//광역데미지일때 이코드
        {
            Explode();
        }
        else//광역데미지가 아니라면 아래 코드
        {

        }


        yield return null;
        StopCoroutine(HitTarget());
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

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();


        if(e != null)
        {
            //포탑의 공격력만큼
            //e.TakeDamage(10f,);
        }



    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
