using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MngEnemy : MonoBehaviour
{
    [Header("몬스터 프리팹")]
    //----Transform
    public Transform[] enemyPrefabs;
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
    private int waveIndex = 0;


    public enum WaveThema
    {
        NONE,
        Default,//일반
        AIR,//공중 혼합
        
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

}
