using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Enemy : MonoBehaviour
{
    private Btn3x3 btn3x3;
   
    protected float maxHp;
    protected float nowHp;

    protected float startSpeed;
    protected float speed;

    protected Transform target;
    
    
    protected RectTransform hpBar;
    protected GameObject hpBarObj;

    protected int waypointindex = 0;

    protected int reward;



    /// <summary>
    /// Ư���� �Ͻ�
    /// </summary>
    protected List<int> types;

    //�Ӽ���
    protected enum TYPES
    {
        Default,
        SMALL,
        Middle,
        BIG,
    }

    private void Start()
    {
        speed = startSpeed;
        btn3x3 = GameManager.instance.btn3x3Obj.GetComponent<Btn3x3>();
    }

    protected void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        Debug.Log("Enemy");
        GameManager.instance.btn_3x3_state = GameManager.Btn_3x3_state.CLICK_ENEMY;

        #region btn 3x3 Setting
        //0
        btn3x3.ClearSet(0);

        //1
        btn3x3.ClearSet(1);

        //2
        btn3x3.ClearSet(2);

        //3
        btn3x3.ClearSet(3);

        //4
        btn3x3.ClearSet(4);

        //5
        btn3x3.ClearSet(5);

        //6
        btn3x3.ClearSet(6);

        //7
        btn3x3.ClearSet(7);

        //8
        btn3x3.ClearSet(8);
        #endregion
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
        //PlayerStats.Money += reward;
        this.gameObject.SetActive(false);
    }


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
        else
        {
            waypointindex++;
            target = GameManager.instance.waypoints[waypointindex];
        }
    }

    /// <param name="myPos"> �� ��ġ</param>
    public void MoveToTarget(Transform myPos, float moveSpeed)
    {
        Vector3 dir = target.position - myPos.position;
        myPos.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
 

        if (Vector3.Distance(myPos.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();

            // ĳ���� ȸ��
            myPos.LookAt(target);
            // ü�¹� ȸ�� 
            rotateHpbar(hpBar);
        }
    }

    public void EndPath()
    {
        //������ ����Ʈ ����
        //PlayerStats.lives--;
        this.gameObject.SetActive(false);
       
    }

    protected void rotateHpbar(RectTransform hpBar)
    {
        Quaternion rotationOffset = Quaternion.Euler(70, 0, 0);

        hpBar.transform.rotation = rotationOffset;
    }

}
