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
    private bool isWave = false;

    //----float
    [Header("WaveTimer")]
    public float timerWave = 30;

    private float countdown = 3.0f;


    //----int
    //10���̺����, 10���̺�� ����
    private int waveIndex = 0;


    //----GameObject
    TextMeshProUGUI textTime;

    private void Start()
    {
        textTime = GameManager.instance.Canvas.Find("Timer/TextTimer").gameObject.GetComponent<TextMeshProUGUI>();
        Debug.Log(textTime);
    }

    private void Update()
    {
        SpawnWave();
        WaveTimer(countdown);
    }

    public void WaveTimer(float time)
    {
        int minute = (int)(time / 60);
        int second = (int)(time % 60);

        textTime.text = $"{minute:D2}:{second:D2}";
    }

    public void SpawnWave()
    {
        isWave = true;
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            Debug.Log("Wave Incomming!");

            // ���⼭ ����ġ���� ���ؼ� ���� ��ȯ�� �����ϸ�ǰڴ�
            StartCoroutine(SpawnEnemyCouroutine());
            

            countdown = timerWave;
        }
    }

    public void TimerWork()
    {
        
    }

    IEnumerator SpawnEnemyCouroutine()
    {
        Debug.Log("3");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("2");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("1");
        yield return new WaitForSeconds(1.0f);

        GameObject insMob = Instantiate(enemyPrefabs[0], spawnPoint.position, spawnPoint.rotation).gameObject;

        insMob.transform.parent = GameManager.instance.activePool;

        waveIndex++;
       
        yield return new WaitForSeconds(1.0f);
    }

}
