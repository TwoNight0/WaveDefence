using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float maxHp;
    protected float nowHp;

    private float startSpeed;
    private float speed;

    protected int reward;


    private void Start()
    {
        speed = startSpeed;
    }
    /// <summary>
    /// ����, ���� ������ �Ѵ� ���
    /// </summary>
    public void TakeDamage(float ad, float ap)
    {
        nowHp -= (ad+ap) ;

        if(nowHp <= 0)
        {
            Die();
        }
    }
    /// <summary>
    /// ���ο�� �ɾ����� ������ �ӵ��� �ٽ� �ǵ����ִ� ������ �ʿ��ϴ�
    /// </summary>
    /// <param name="pct"></param>
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }


    public void Die()
    {
        //���߰�
        PlayerStats.Money += reward;
        this.gameObject.SetActive(false);
    }
}
