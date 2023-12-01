using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float maxHp;
    protected float nowHp;
    protected float moveSpeed = 1.0f;
    

    protected Transform target;
    protected int waypointindex = 0;

    /// <param name="myPos"> 내 위치</param>
    public void MoveTarget(Transform myPos)
    {
        Vector3 dir = target.position - myPos.position;
        myPos.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        if(Vector3.Distance(myPos.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    /// <summary>
    /// 다음 웨이포인트를 가져옴
    /// </summary>
    public void GetNextWaypoint()
    {
        if( waypointindex >= GameManager.instance.waypoints.Length -1)
        {
            this.gameObject.SetActive(false);
            return;
        }

        waypointindex++;
        target = GameManager.instance.waypoints[waypointindex];
    }

}
