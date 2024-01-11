using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngShop : MonoBehaviour
{
    public static MngShop instance;

    public List<GameObject> unit_list;

    public Transform unitSpawnPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectStandardTurret()
    {
       

    }

  
}
