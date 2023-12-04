using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemont : MonoBehaviour
{

    protected Transform target;
    protected int waypointindex = 0;
    protected float moveSpeed = 1.0f;
    /// <summary>
    /// ���� ��������Ʈ�� ������
    /// </summary>
    public void GetNextWaypoint()
    {
        //������ ����������
        if (waypointindex >= GameManager.instance.waypoints.Length - 1)
        {
            EndPath();

            return;
        }

        waypointindex++;
        target = GameManager.instance.waypoints[waypointindex];
    }

    /// <param name="myPos"> �� ��ġ</param>
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
