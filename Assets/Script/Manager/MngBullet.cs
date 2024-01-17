using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngBullet : MonoBehaviour
{
    public static MngBullet instance; // Singleton 패턴을 사용하여 총알 풀을 전역에서 접근 가능하게 합니다.

    public int offsetAddBullet = 5;
    #region Bullets

    public GameObject arrow; // 캐릭터 A의 총알 프리팹
    public GameObject bulletPrefabB; // 캐릭터 B의 총알 프리팹

    #endregion

    private Dictionary<string, Queue<GameObject>> bulletPools;

    void Awake()
    {
        instance = this;

        // 총알 풀 초기화
        bulletPools = new Dictionary<string, Queue<GameObject>>();
        InitializeBulletPool("Archer", arrow, 10); // 예시로 10개의 총알을 할당합니다.
        //InitializeBulletPool("CharacterB", bulletPrefabB, 10);
    }

    /// <summary>
    /// 불렛 풀 생성
    /// </summary>
    /// <param name="_characterType"></param>
    /// <param name="bulletPrefab"></param>
    /// <param name="poolSize"></param>
    void InitializeBulletPool(string _characterType, GameObject bulletPrefab, int poolSize)
    {
        if (!bulletPools.ContainsKey(_characterType))
        {
            bulletPools[_characterType] = new Queue<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                //총알에 타입을 배정
                bulletScript.characterType = _characterType;

                bullet.SetActive(false);
                bulletPools[_characterType].Enqueue(bullet);
            }
        }
    }

    /// <summary>
    /// 불렛 가져오기
    /// </summary>
    /// <param name="characterType"></param>
    /// <returns></returns>
    public GameObject GetBullet(string characterType)
    {
        if (bulletPools.ContainsKey(characterType) && bulletPools[characterType].Count > 1)
        {
            GameObject bullet = bulletPools[characterType].Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else if (bulletPools.ContainsKey(characterType) && bulletPools[characterType].Count == 1)
        {
            //1개 복사
            GameObject bulletprefab = bulletPools[characterType].Dequeue();

            for (int i = 0; i < offsetAddBullet; i++)
            {
                GameObject bullet = Instantiate(bulletprefab);
                bullet.SetActive(false);
                bulletPools[characterType].Enqueue(bullet);
            }
            return bulletprefab;
        }
        else
        {
            // 풀에 총알이 부족한 경우 추가적으로 생성하거나 예외 처리할 수 있습니다.
            Debug.LogWarning("Bullet pool empty for character type: " + characterType);
            return null;
        }
    }


    /// <summary>
    /// 다시 풀에 집어넣기
    /// </summary>
    /// <param name="characterType"></param>
    /// <param name="bullet"></param>
    public void ReturnBullet(string characterType, GameObject bullet)
    {
        transform.position = Vector3.up * 100;
        bullet.SetActive(false);
        bulletPools[characterType].Enqueue(bullet);
    }
}
