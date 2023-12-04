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
    /// 물리, 마법 데미지 둘다 고려
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
    /// 슬로우는 걸었지만 끝나면 속도를 다시 되돌려주는 과정이 필요하다
    /// </summary>
    /// <param name="pct"></param>
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }


    public void Die()
    {
        //돈추가
        PlayerStats.Money += reward;
        this.gameObject.SetActive(false);
    }
}
