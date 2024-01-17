using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public RectTransform Canvas;

    public Transform[] waypoints;

    public Transform activePool;
    public Transform recyclePool;

    [Header("조합")]
    public Transform combination1;
    public Transform combination2;
    public Transform combination3;

    [Header("3x3 버튼")]
    public GameObject btn3x3Obj;
    public List<Button> ListBtn_3x3;


    public GameObject allowMoveObj;
    public Btn_3x3_state btn_3x3_state;
    public GameState gameState;

    public bool isReady = false;
    public bool isWave = false;


    private bool isEnd = false;

    [HideInInspector]public PlayerStats playerStats;

    /// <summary>
    /// 게임 상황 
    /// </summary>
    public enum GameState
    {
        None,
        Ready,
        Wave,
        Defeat,
        Victory
    }


    /// <summary>
    /// 3x3버튼
    /// </summary>
    public enum Btn_3x3_state
    {
        NONE,
        CLICK_Unit,
        CLICK_ENEMY,
        CLICK_NEXUS,
        CLICK_MAGICSHOP,
        CLICK_UPGRADESHOP,
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
       
        isReady = true;

        btn_3x3_state = Btn_3x3_state.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 게임패배
    /// </summary>
    void LifeZero()
    {
        //if (PlayerStats.lives <= 0)
        //{
        //    isEnd = true;
        //    EndGame();
        //}
    }

    void EndGame() 
    {
        if (isEnd)
        {
            Debug.Log("Game Over");
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// 라운드 시작버튼
    /// </summary>
    private void BtnRound()
    {
        isWave = true;
    }

    /// <summary>
    /// 조합표
    /// </summary>
    private void BtnCombinationExplain()
    {

    }

    /// <summary>
    /// 조합버튼
    /// </summary>
    private void BtnCombination()
    {

    }
}
