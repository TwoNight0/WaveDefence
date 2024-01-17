using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private int gold;
    private int iron;
    private int wood;
    private int population;
    private int MaxPopulation = 5;
    private int lives;
    private int round = 1;
    private int LastRound = 4;

    //start
    private int startGold = 100;
    private int startIron = 0;
    private int startWood = 0;
    private int startPopulation = 0;
    private int startLives = 10;


    #region UIText
    //monster
    private TextMeshProUGUI TextMagicDefence;
    private TextMeshProUGUI TextPhsicDefence;
    private TextMeshProUGUI TextMoveSpeed;

    //unit
    private TextMeshProUGUI TextAttackDamage;
    private TextMeshProUGUI TextAttackSpeed;
    private TextMeshProUGUI TextRange;
    private TextMeshProUGUI TextMagic;
    private TextMeshProUGUI TextMana;
    private TextMeshProUGUI TextSkillDamage;
    private TextMeshProUGUI TextCritical;
    private TextMeshProUGUI TextSkillCoolDown;
    private TextMeshProUGUI TextUnitMoveSpeed;


    //UI
    private TextMeshProUGUI TextName;
    private TextMeshProUGUI TextGold;
    private TextMeshProUGUI TextIron;
    private TextMeshProUGUI TextWood;
    private TextMeshProUGUI TextPopulation;
    private TextMeshProUGUI TextLife;
    private TextMeshProUGUI TextRound;
    private TextMeshProUGUI TextInformation;
    #endregion

    private RectTransform canvas;
    private RectTransform topFrame;
    private RectTransform mainFrame;
    private RectTransform mainFrame_Monster;
    private RectTransform mainFrame_Unit;

    private Image portrait;

    #region pub

    public int PubMoney
    {
        get => gold;
        set => gold = value;
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

    public int PubRound
    {
        get => round;
        set => round = value;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        UIInit();
        UpdateUI();
        TextName.enabled = false;
    }

    public void UIInit()
    {
        canvas = GameManager.instance.Canvas;

        topFrame = canvas.Find("TopFrame").GetComponent<RectTransform>();
        mainFrame = canvas.Find("MainFrame").GetComponent<RectTransform>();

        mainFrame_Monster = mainFrame.Find("Monster").GetComponent<RectTransform>();
        mainFrame_Unit = mainFrame.Find("Unit").GetComponent<RectTransform>();

        portrait = mainFrame.Find("portraitBack").GetChild(0).GetComponent<Image>();

        gold = startGold;
        iron = startIron;
        wood = startWood;
        population = startPopulation;
        lives = startLives;

        //UI
        TextName = mainFrame.Find("Text_Name").GetComponent<TextMeshProUGUI>();
        TextGold = topFrame.Find("Gold").GetChild(0).GetComponent<TextMeshProUGUI>();
        TextIron = topFrame.Find("Iron").GetChild(0).GetComponent<TextMeshProUGUI>();
        TextWood = topFrame.Find("Wood").GetChild(0).GetComponent<TextMeshProUGUI>();
        TextPopulation = topFrame.Find("Population").GetChild(0).GetComponent<TextMeshProUGUI>();
        TextLife = topFrame.Find("Life").GetChild(0).GetComponent<TextMeshProUGUI>();
        TextRound = topFrame.Find("Round").GetChild(0).GetComponent<TextMeshProUGUI>();
        TextInformation = canvas.Find("Information").GetComponent<TextMeshProUGUI>();

        //monster
        TextPhsicDefence = mainFrame_Monster.Find("PhygicDefance").GetComponent<TextMeshProUGUI>();
        TextMagicDefence = mainFrame_Monster.Find("MagicDefance").GetComponent<TextMeshProUGUI>(); 
        TextMoveSpeed = mainFrame_Monster.Find("MoveSpeed").GetComponent<TextMeshProUGUI>(); 

        //Unit
        TextAttackDamage = mainFrame_Unit.Find("AttackDamage").GetComponent<TextMeshProUGUI>(); 
        TextAttackSpeed = mainFrame_Unit.Find("AttackSpeed").GetComponent<TextMeshProUGUI>(); 
        TextRange = mainFrame_Unit.Find("Range").GetComponent<TextMeshProUGUI>(); 
        TextMagic = mainFrame_Unit.Find("Magic").GetComponent<TextMeshProUGUI>(); 
        TextMana = mainFrame_Unit.Find("Mana").GetComponent<TextMeshProUGUI>(); 
        TextSkillDamage = mainFrame_Unit.Find("SKillDamage").GetComponent<TextMeshProUGUI>(); 
        TextCritical = mainFrame_Unit.Find("Critical ").GetComponent<TextMeshProUGUI>(); 
        TextSkillCoolDown = mainFrame_Unit.Find("SkillCoolDown").GetComponent<TextMeshProUGUI>(); 
        TextUnitMoveSpeed = mainFrame_Unit.Find("UnitMoveSpeed").GetComponent<TextMeshProUGUI>();

        //off
        mainFrame_Monster.gameObject.SetActive(false);
        mainFrame_Unit.gameObject.SetActive(false);
        portrait.enabled = false;
    }

    /// <summary>
    /// 유아이 업데이트
    /// </summary>
    public void UpdateUI() {
        TextName.enabled = true;
        TextGold.text = gold.ToString();
        TextIron.text = iron.ToString();
        TextWood.text = wood.ToString();
        TextPopulation.text = population.ToString() + " / " + MaxPopulation.ToString();
        TextLife.text = lives.ToString();
        TextRound.text = "Round " + round.ToString() + " / " + LastRound.ToString();
    }

    public void AnnounceInfo(string information)
    {
        TextInformation.text = information;
    }

    public void UpdateMonsterUI(string name, float phsicDefence, float magicDefence, float moveSpeed)
    {
        TextName.text = name;
        TextPhsicDefence.text = phsicDefence.ToString();
        TextMagicDefence.text = magicDefence.ToString();
        TextMoveSpeed.text = moveSpeed.ToString();
    }

    public void UpdateUnitUI(string name, float attackDamage, float attackSpeed, float range, 
        float magic, int mana, float skillDamage, float critical, float skillCoolDown, float moveSpeed  )
    {
        //꺼진거 다시켜주기
        mainFrame_Unit.gameObject.SetActive(true);
        TextName.enabled = true;
        portrait.enabled = true;

        //데이터 입력
        TextName.text = name;
        TextAttackDamage.text = attackDamage.ToString();
        TextAttackSpeed.text = attackSpeed.ToString();
        TextRange.text = range.ToString();
        TextMagic.text = magic.ToString();
        TextMana.text = mana.ToString();
        TextSkillDamage.text = skillDamage.ToString();
        TextCritical.text = critical.ToString();
        TextSkillCoolDown.text = skillCoolDown.ToString();
        TextUnitMoveSpeed.text = moveSpeed.ToString();
    }

}
