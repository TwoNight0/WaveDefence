using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemont : MonoBehaviour
{

    protected Transform target;
    protected int waypointindex = 0;
    protected float moveSpeed = 1.0f;
    /// <summary>
    /// 다음 웨이포인트를 가져옴
    /// </summary>
    public void GetNextWaypoint()
    {
        //끝까지 완주했을때
        if (waypointindex >= GameManager.instance.waypoints.Length - 1)
        {
            EndPath();

            return;
        }

        waypointindex++;
        target = GameManager.instance.waypoints[waypointindex];
    }

    /// <param name="myPos"> 내 위치</param>
    public void MoveTarget(Transform myPos)
    {
        Vector3 dir = target.position - myPos.position;
        myPos.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(myPos.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    public void EndPath()
    {
        PlayerStats.lives--;
        this.gameObject.SetActive(false);
    }
}
