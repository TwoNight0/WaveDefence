using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//이렇게 직렬화 하지않으면 다른오브젝트에서 스크립트 내부를 볼수없다
[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;
}
