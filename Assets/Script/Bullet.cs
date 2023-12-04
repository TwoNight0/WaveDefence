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
        //�̰� �����ļ� OnCollison�����Ѵ��� tag�� Monster�� �ν��������� �ٲ��� �̷����ϸ� �̹� ���͵� �Ÿ��� üũ�ϴµ� �Ѿ˱��� �Ÿ��� üũ�ϴ� ������ؾ���

        //if (target == null)
        //{
        //    //bullet ��Ȱ�� Ǯ�� �̵�
        //    gameObject.transform.parent = GameManager.instance.recyclePool.Find("Bullet_Pool");
        //    gameObject.SetActive(false);
        //    return;
        //}

        //Vector3 dir = target.position - transform.position;


        //float distanceThisFrame = speed * Time.deltaTime;

        ////�����Ӵ� �̵��ؾ��� �Ÿ����� Ÿ����� �Ÿ��� �۴ٸ� �浹�Ѱ�
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



    //�ʹ� �ݺ��� ����ȭ�ؾ���
    IEnumerator HitTarget()
    {
        Debug.Log("�浹");

        //�ı� ȿ��
        GameObject insEffect = (GameObject)Instantiate(bulletImpactEffect, transform.position, transform.rotation);

        yield return new WaitForSeconds(2.0f);

        //bullet Effect�� ��Ȱ�� Ǯ�� �̵�
        insEffect.transform.parent = GameManager.instance.recyclePool.Find("Effect_Pool");
        insEffect.SetActive(false);

        //bullet�� ��Ȱ�� Ǯ�� �̵�
        gameObject.transform.parent = GameManager.instance.recyclePool.Find("Bullet_Pool");
        gameObject.SetActive(false);

        //target�� ��Ȱ�� Ǯ�� �̵�
        target.parent = GameManager.instance.recyclePool.Find("Monster_Pool");
        target.gameObject.SetActive(false);

        if(explosionRadius > 0f)//�����������϶� ���ڵ�
        {
            Explode();
        }
        else//������������ �ƴ϶�� �Ʒ� �ڵ�
        {

        }


        yield return null;
        StopCoroutine(HitTarget());
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

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();


        if(e != null)
        {
            //��ž�� ���ݷ¸�ŭ
            //e.TakeDamage(10f,);
        }



    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
