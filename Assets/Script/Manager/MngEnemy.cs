using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MngEnemy : MonoBehaviour
{
    [Header("몬스터 프리팹")]
    //----Transform
    public List<GameObject> enemyPrefabs;
    public Transform spawnPoint;

    //----bool
    //private bool isWave = false;

    //----float
    [Header("WaveTimer")]
    public float timerWave = 30;

    private float countdown = 3.0f;

    private WaveThema wavethema = WaveThema.NONE;

    //----int
    //10웨이브까지, 4웨이브면 보스 1,2,3,4

    #region 몬스터 넘버링
    private int mob_Bat = -1;
    private int mob_Bee = -1;
    private int mob_Beholder = -1;
    private int mob_Bishopknight = -1;
    private int mob_BlackKnight = -1;
    private int mob_Cactus = -1;
    private int mob_Chest = -1;
    private int mob_Crab = -1;
    private int mob_Cyclops = -1;
    private int mob_Demonking = -1;
    private int mob_Dragon = -1;
    private int mob_EvilMage = -1;
    private int mob_Fishman = -1;
    private int mob_FylingDemon = -1;
    private int mob_Golem = -1;
    private int mob_LizardWarrior = -1;
    private int mob_MushroomAngry = -1;
    private int mob_MushroomSmile = -1;
    private int mob_NageWizard = -1;
    private int mob_Orc = -1;
    private int mob_RatAssassin = -1;
    private int mob_Salamander = -1;
    private int mob_Skeleton = -1;
    private int mob_Slime = -1;
    private int mob_Specter = -1;
    private int mob_Spider = -1;
    private int mob_StringRay = -1;
    private int mob_TurtleShell = -1;
    private int mob_VenusPlant = -1;
    private int mob_Wolf = -1;
    private int mob_Worm = -1;
    #endregion

    private int waveIndex = 0;

    public enum WaveThema
    {
        NONE,
        Default,//일반
        AIR,//공중 혼합
        
    }

    private void Awake()
    {
        InitMonsterNumbering();
    }

    private void Start()
    {
        //랜덤으로 정해주기
        wavethema = WaveThema.Default;

        //웨어울프 하나 소환
        //소환하고 높이 지정을 좀해줘야할듯
        Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation);

    }

    private void Update()
    {
        //SpawnWave();
        //WaveTimer(countdown);
    }


    /// <summary>
    /// 웨이브 소환
    /// </summary>
    public void SpawnWave()
    {
        if (countdown <= 0f)
        {
            Debug.Log("Wave Incomming!");

            // 여기서 스위치문을 통해서 몬스터 소환을 관리하면되겠다
            StartCoroutine(SpawnEnemyCouroutine());
            

            countdown = timerWave;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        
    }

    /// <summary>
    /// 스폰 및 라운드 구성
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnEnemyCouroutine()
    {
        int round = GameManager.instance.PubRound;
        if (wavethema == WaveThema.Default)
        {
#region 일반테마 라운드 구성
            switch (round)
            {
                case 1:
                    //몬스터 소환
                    GameObject insMob_bat1 = Instantiate(enemyPrefabs[mob_Bat], spawnPoint.position, spawnPoint.rotation).gameObject;
                    insMob_bat1.transform.parent = GameManager.instance.activePool;

                    yield return new WaitForSeconds(0.5f);

                    GameObject insMob_bat = Instantiate(enemyPrefabs[mob_Bat], spawnPoint.position, spawnPoint.rotation).gameObject;
                    insMob_bat1.transform.parent = GameManager.instance.activePool;

                    break;
                case 2:
                    //몬스터 소환
                    GameObject insMob2 = Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation).gameObject;
                    insMob2.transform.parent = GameManager.instance.activePool;
                    break;
                case 3:
                    //몬스터 소환
                    GameObject insMob3 = Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation).gameObject;
                    insMob3.transform.parent = GameManager.instance.activePool;
                    break;
                case 4:
                    break;

#endregion
            }
        }
        else if(wavethema == WaveThema.AIR)
        {
            switch (round)
            {
#region 공중테마 라운드 구성
                case 1:
                    //몬스터 소환
                    GameObject insMob = Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation).gameObject;
                    insMob.transform.parent = GameManager.instance.activePool;
                    yield return new WaitForSeconds(0.2f);

                    break;
                case 2:
                    //몬스터 소환
                    GameObject insMob2 = Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation).gameObject;
                    insMob2.transform.parent = GameManager.instance.activePool;
                    break;
                case 3:
                    //몬스터 소환
                    GameObject insMob3 = Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation).gameObject;
                    insMob3.transform.parent = GameManager.instance.activePool;
                    break;
                case 4:
                    break;
#endregion
            }
        }


        waveIndex++;
       
        yield return new WaitForSeconds(1.0f);
    }

    #region 몬스터에 코드 부여하기
    /// <summary>
    /// 몬스터 넘버를 부여해 좀더 코드를 볼때 수월하게함
    /// </summary>
    private void InitMonsterNumbering()
    {
        mob_Bat = asignNumberToMonster("mob_Bat");
        mob_Bee = asignNumberToMonster("mob_Bee");
        mob_Beholder = asignNumberToMonster("mob_Beholder");
        mob_Bishopknight = asignNumberToMonster("mob_Bishopknight");
        mob_BlackKnight = asignNumberToMonster("mob_BlackKnight");
        mob_Cactus = asignNumberToMonster("mob_Cactus");
        mob_Chest = asignNumberToMonster("mob_Chest");
        mob_Crab = asignNumberToMonster("mob_Crab");
        mob_Cyclops = asignNumberToMonster("mob_Cyclops"); ;
        mob_Demonking = asignNumberToMonster("mob_Demonking");
        mob_Dragon = asignNumberToMonster("mob_Dragon");
        mob_EvilMage = asignNumberToMonster("mob_EvilMage");
        mob_Fishman = asignNumberToMonster("mob_Fishman");
        mob_FylingDemon = asignNumberToMonster("mob_FylingDemon");
        mob_Golem = asignNumberToMonster("mob_Golem");
        mob_LizardWarrior = asignNumberToMonster("mob_LizardWarrior");
        mob_MushroomAngry = asignNumberToMonster("mob_MushroomAngry");
        mob_MushroomSmile = asignNumberToMonster("mob_MushroomSmile");
        mob_NageWizard = asignNumberToMonster("mob_NageWizard");
        mob_Orc = asignNumberToMonster("mob_Orc");
        mob_RatAssassin = asignNumberToMonster("mob_RatAssassin");
        mob_Salamander = asignNumberToMonster("mob_Salamander");
        mob_Skeleton = asignNumberToMonster("mob_Skeleton");
        mob_Slime = asignNumberToMonster("mob_Slime");
        mob_Specter = asignNumberToMonster("mob_Specter");
        mob_Spider = asignNumberToMonster("mob_Spider");
        mob_StringRay = asignNumberToMonster("mob_StringRay");
        mob_TurtleShell = asignNumberToMonster("mob_TurtleShell");
        mob_VenusPlant = asignNumberToMonster("mob_VenusPlant");
        mob_Wolf = asignNumberToMonster("mob_Wolf");
        mob_Worm = asignNumberToMonster("mob_Worm");
    }

    private int asignNumberToMonster(string monsterStringName)
    {
        return enemyPrefabs.FindIndex(x => x.name == monsterStringName);
    }

    #endregion


}
