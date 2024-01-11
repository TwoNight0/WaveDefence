using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int money;
    private int startMoney;
    private int wood;
    private int iron;
    private int population;
    private int lives;

    private int startLives = 20;

    public int PubMoney
    {
        get => money;
        set => money = value;
    }

    public int PubWood
    {
        get => wood;
        set => wood = value;
    }

    public int Pubiron
    {
        get => iron;
        set => iron = value;
    }

    public int Pubpopulation
    {
        get => population;
        set => population = value;
    }

    public int Publives
    {
        get => lives;
        set => lives = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        lives = startLives;
        money = startMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
