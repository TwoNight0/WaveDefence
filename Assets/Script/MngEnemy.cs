using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngEnemy : MonoBehaviour
{
    [Header("���� ������")]
    public Transform[] enemyPrefabs;

    public Transform spawnPoint;

    public float time_wave = 5.0f;
    private float countdown;

}
