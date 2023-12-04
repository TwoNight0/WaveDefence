using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public RectTransform Canvas;

    public Transform[] waypoints;

    public Transform activePool;
    public Transform recyclePool;

    private bool isEnd = false;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LifeZero()
    {
        if (PlayerStats.lives <= 0)
        {
            isEnd = true;
            EndGame();
        }
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
