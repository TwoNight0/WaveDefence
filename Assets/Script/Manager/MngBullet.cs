using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngBullet : MonoBehaviour
{
    public static MngBullet instance; // Singleton ������ ����Ͽ� �Ѿ� Ǯ�� �������� ���� �����ϰ� �մϴ�.

    public int offsetAddBullet = 5;
    #region Bullets

    public GameObject arrow; // ĳ���� A�� �Ѿ� ������
    public GameObject bulletPrefabB; // ĳ���� B�� �Ѿ� ������

    #endregion

    private Dictionary<string, Queue<GameObject>> bulletPools;

    void Awake()
    {
        instance = this;

        // �Ѿ� Ǯ �ʱ�ȭ
        bulletPools = new Dictionary<string, Queue<GameObject>>();
        InitializeBulletPool("Archer", arrow, 10); // ���÷� 10���� �Ѿ��� �Ҵ��մϴ�.
        //InitializeBulletPool("CharacterB", bulletPrefabB, 10);
    }

    /// <summary>
    /// �ҷ� Ǯ ����
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
                //�Ѿ˿� Ÿ���� ����
                bulletScript.characterType = _characterType;

                bullet.SetActive(false);
                bulletPools[_characterType].Enqueue(bullet);
            }
        }
    }

    /// <summary>
    /// �ҷ� ��������
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
            //1�� ����
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
            // Ǯ�� �Ѿ��� ������ ��� �߰������� �����ϰų� ���� ó���� �� �ֽ��ϴ�.
            Debug.LogWarning("Bullet pool empty for character type: " + characterType);
            return null;
        }
    }


    /// <summary>
    /// �ٽ� Ǯ�� ����ֱ�
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
