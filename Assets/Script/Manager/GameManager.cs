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

    public List<Button> btn_3x3;

    public GameObject allowMoveObj;

    public Btn_3x3_state btn_3x3_state;

    public bool isReady = false;
    public bool isWave = false;


    private bool isEnd = false;

    private int round = 1;

    [HideInInspector]public PlayerStats playerStats;

    public int PubRound
    {
        get => round;
        set => round = value;
    }

    public enum Btn_3x3_state
    {
        NONE,
        CLICK_CHARACTOR,
        CLICK_NEXUS,
        CLICK_NOMAL_UNIT,
        CLICK_RARE_UNIT,
        CLICK_UNIQUE_UNIT,
        CLICK_LEGENDARY_UNIT,
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


}
