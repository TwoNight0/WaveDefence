using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public abstract class Enemy : MonoBehaviour
{
    protected Btn3x3 btn3x3;
   
    protected float maxHp;
    protected float nowHp;
    protected float physic_Defence = 0;
    protected float magic_Defence = 0;

    protected float startSpeed;
    protected float speed;

    protected Transform target;
    
    protected RectTransform hpBar;
    protected Animator anim;
    protected GameObject hpBarObj;
    protected Slider hpSlider;

    protected int waypointindex = 0;
    protected int reward;

    protected bool isMove = true;

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
        //�������� �ظ��ϸ� ���º��� ������..?
        ad -= physic_Defence;
        ap -= magic_Defence;

        nowHp -= (ad+ap) ;

        HpbarUpdate(hpSlider);

        if (nowHp <= 0)
        {
            StartCoroutine(Die());
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


    protected IEnumerator Die()
    {
        isMove = false;
        //���߰�
        GameManager.instance.playerStats.PubMoney += reward;
        GameManager.instance.playerStats.UpdateUI();

        //�� �ö󰡴� ���� �߰� 

        //�� �ö󰡴� �ִϸ��̼� �߰�

        gameObject.transform.parent = GameManager.instance.recyclePool;

        //��� ���� �߰�

        anim.SetTrigger("Die");

        yield return new WaitForSeconds(0.5f);

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
        if (isMove != true)
        {
            return;
        }

        Vector3 dir = target.position - myPos.position;
        myPos.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);


        if (Vector3.Distance(myPos.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();

            // ĳ���� ȸ��
            myPos.LookAt(target);
            // ü�¹� ȸ�� 
            rotateHpbar(hpBar, new Vector3(-77, 180, 0));
        }
    }

    public void EndPath()
    {
        //������ ����Ʈ ����
        //PlayerStats.lives--;
        this.gameObject.SetActive(false);
    }

    protected void rotateHpbar(RectTransform hpBar, Vector3 _vector3)
    {
        Quaternion rotationOffset = Quaternion.Euler(_vector3);
        hpBar.transform.rotation = rotationOffset;
    }

    /// <summary>
    /// �ٲ� ü���� �����Ŵ
    /// </summary>
    /// <param name="_slider"></param>
    private void HpbarUpdate(Slider _slider)
    {
        //Debug.Log(nowHp / maxHp);
        _slider.DOValue(maxHp * (nowHp / maxHp), 0.4f);
    }

    /// <summary>
    /// ���Ͽ� �¾�����
    /// </summary>
    protected IEnumerator AnimDizzy(float _Dizzytime)
    {
        Debug.Log("����@!");
        //��񵿾� ��ٷȴٰ� �ٽ� �ൿ����

        isMove = false;
        
        anim.SetBool("isDizzy", true);

        yield return new WaitForSeconds(_Dizzytime);

        anim.SetBool("isDizzy", false);

        yield return new WaitForSeconds(0.1f);

        isMove = true;
    }

}
