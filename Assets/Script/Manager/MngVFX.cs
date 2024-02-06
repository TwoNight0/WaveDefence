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

    //물리 데미지 이펙트
    public GameObject effectPhysicDamage;
    //마법 데미지 이펙트
    public GameObject effectMagicDamage;
    //돈이펙트, 
    public GameObject effectMoney;

    //텍스트
    //물리 데미지 텍스트
    public TextMeshProUGUI TextPhysicDamage;
    //마법 데미지 텍스트
    public TextMeshProUGUI TextMagicDamage;
    //돈 텍스트
    public TextMeshProUGUI TextMoneyDamage;




    void Start()
    {
        //라이트 
        GameObject flashInstance = Instantiate(flash, transform.position, Quaternion.identity);
        flashInstance.transform.forward = gameObject.transform.forward;

        // setOff로 변경 및 재활용할수있게 만들기
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
        //충돌지점 받아오기
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

