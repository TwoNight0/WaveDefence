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
    /// 특성을 암시
    /// </summary>
    protected List<int> types;

    //속성들
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
    /// 물리, 마법 데미지 둘다 고려
    /// </summary>
    public void TakeDamage(float ad, float ap)
    {
        //데미지가 왠만하면 방어력보다 높겠지..?
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
    /// 슬로우는 걸었지만 끝나면 속도를 다시 되돌려주는 과정이 필요하다
    /// </summary>
    /// <param name="pct"></param>
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }


    protected IEnumerator Die()
    {
        isMove = false;
        //돈추가
        GameManager.instance.playerStats.PubMoney += reward;
        GameManager.instance.playerStats.UpdateUI();

        //돈 올라가는 사운드 추가 

        //돈 올라가는 애니메이션 추가

        gameObject.transform.parent = GameManager.instance.recyclePool;

        //사망 사운드 추가

        anim.SetTrigger("Die");

        yield return new WaitForSeconds(0.5f);

        this.gameObject.SetActive(false);


    }


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
        else
        {
            waypointindex++;
            target = GameManager.instance.waypoints[waypointindex];
        }
    }

    /// <param name="myPos"> 내 위치</param>
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

            // 캐릭터 회전
            myPos.LookAt(target);
            // 체력바 회전 
            rotateHpbar(hpBar, new Vector3(-77, 180, 0));
        }
    }

    public void EndPath()
    {
        //라이프 포인트 차감
        //PlayerStats.lives--;
        this.gameObject.SetActive(false);
    }

    protected void rotateHpbar(RectTransform hpBar, Vector3 _vector3)
    {
        Quaternion rotationOffset = Quaternion.Euler(_vector3);
        hpBar.transform.rotation = rotationOffset;
    }

    /// <summary>
    /// 바뀐 체력을 적용시킴
    /// </summary>
    /// <param name="_slider"></param>
    private void HpbarUpdate(Slider _slider)
    {
        //Debug.Log(nowHp / maxHp);
        _slider.DOValue(maxHp * (nowHp / maxHp), 0.4f);
    }

    /// <summary>
    /// 스턴에 맞았을때
    /// </summary>
    protected IEnumerator AnimDizzy(float _Dizzytime)
    {
        Debug.Log("기절@!");
        //잠깐동안 기다렸다가 다시 행동시작

        isMove = false;
        
        anim.SetBool("isDizzy", true);

        yield return new WaitForSeconds(_Dizzytime);

        anim.SetBool("isDizzy", false);

        yield return new WaitForSeconds(0.1f);

        isMove = true;
    }

}
