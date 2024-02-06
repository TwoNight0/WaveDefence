using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MngVFX : MonoBehaviour
{

    public float hitOffset = 0f;

    public Vector3 rotationOffset = new Vector3(0, 0, 0);
    public bool UseFirePointRotation;

    public GameObject flash;
    public GameObject[] Detached;
    public GameObject bulletImpactEffect;
    public GameObject hit;

    //���� ������ ����Ʈ
    public GameObject effectPhysicDamage;
    //���� ������ ����Ʈ
    public GameObject effectMagicDamage;
    //������Ʈ, 
    public GameObject effectMoney;

    //�ؽ�Ʈ
    //���� ������ �ؽ�Ʈ
    public TextMeshProUGUI TextPhysicDamage;
    //���� ������ �ؽ�Ʈ
    public TextMeshProUGUI TextMagicDamage;
    //�� �ؽ�Ʈ
    public TextMeshProUGUI TextMoneyDamage;




    void Start()
    {
        //����Ʈ 
        GameObject flashInstance = Instantiate(flash, transform.position, Quaternion.identity);
        flashInstance.transform.forward = gameObject.transform.forward;

        // setOff�� ���� �� ��Ȱ���Ҽ��ְ� �����
        ParticleSystem flashPs = flashInstance.GetComponent<ParticleSystem>();
        if (flashPs != null)
        {
            Destroy(flashInstance, flashPs.main.duration);
        }
        else
        {
            var flashPsParts = flashInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
            Destroy(flashInstance, flashPsParts.main.duration);
        }
        Destroy(gameObject, 5);
    }

  
    public void hitEffect(Collision collision)
    {
   
        //Lock all axes movement and rotation
        //�浹���� �޾ƿ���
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point + contact.normal * hitOffset;

        //Spawn hit effect on collision
        if (hit != null)
        {
            GameObject hitInstance = Instantiate(hit, pos, rot);
            if (UseFirePointRotation) { hitInstance.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180f, 0); }
            else if (rotationOffset != Vector3.zero) { hitInstance.transform.rotation = Quaternion.Euler(rotationOffset); }
            else { hitInstance.transform.LookAt(contact.point + contact.normal); }

            //Destroy hit effects depending on particle Duration time
            ParticleSystem hitPs = hitInstance.GetComponent<ParticleSystem>();
            if (hitPs != null)
            {
                Destroy(hitInstance, hitPs.main.duration);
            }
            else
            {
                var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(hitInstance, hitPsParts.main.duration);
            }
        }

        //Removing trail from the projectile on cillision enter or smooth removing. Detached elements must have "AutoDestroying script"
        foreach (var detachedPrefab in Detached)
        {
            if (detachedPrefab != null)
            {
                detachedPrefab.transform.parent = null;
                Destroy(detachedPrefab, 1);
            }
        }
        //Destroy projectile on collision
        Destroy(gameObject);
    }


}

