using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngEnemy : MonoBehaviour
{
    [Header("몬스터 프리팹")]
    public Transform[] enemyPrefabs;

    public Transform spawnPoint;

    public float time_wave = 5.0f;
    private float countdown;

}
