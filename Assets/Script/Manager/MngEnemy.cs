using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MngEnemy : MonoBehaviour
{
    [Header("���� ������")]
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
    //10���̺����, 4���̺�� ���� 1,2,3,4
    private int waveIndex = 0;


    public enum WaveThema
    {
        NONE,
        Default,//�Ϲ�
        AIR,//���� ȥ��
        
    }

    private void Start()
    {
        //�������� �����ֱ�
        wavethema = WaveThema.Default;

        //������� �ϳ� ��ȯ
        //��ȯ�ϰ� ���� ������ ��������ҵ�
        Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation);

    }

    private void Update()
    {
        //SpawnWave();

        //WaveTimer(countdown);
    }

   

    /// <summary>
    /// ���̺� ��ȯ
    /// </summary>
    public void SpawnWave()
    {
        if (countdown <= 0f)
        {
            Debug.Log("Wave Incomming!");

            // ���⼭ ����ġ���� ���ؼ� ���� ��ȯ�� �����ϸ�ǰڴ�
            StartCoroutine(SpawnEnemyCouroutine());
            

            countdown = timerWave;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        
    }

    /// <summary>
    /// ���� �� ���� ����
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnEnemyCouroutine()
    {
        int round = GameManager.instance.PubRound;
        if (wavethema == WaveThema.Default)
        {
#region �Ϲ��׸� ���� ����
            switch (round)
            {
                case 1:
                    //���� ��ȯ
                    GameObject insMob = Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation).gameObject;
                    insMob.transform.parent = GameManager.instance.activePool;
                    yield return new WaitForSeconds(0.2f);

                    break;
                case 2:
                    //���� ��ȯ
                    GameObject insMob2 = Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation).gameObject;
                    insMob2.transform.parent = GameManager.instance.activePool;
                    break;
                case 3:
                    //���� ��ȯ
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
#region �����׸� ���� ����
                case 1:
                    //���� ��ȯ
                    GameObject insMob = Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation).gameObject;
                    insMob.transform.parent = GameManager.instance.activePool;
                    yield return new WaitForSeconds(0.2f);

                    break;
                case 2:
                    //���� ��ȯ
                    GameObject insMob2 = Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation).gameObject;
                    insMob2.transform.parent = GameManager.instance.activePool;
                    break;
                case 3:
                    //���� ��ȯ
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
