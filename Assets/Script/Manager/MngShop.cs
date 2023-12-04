using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngShop : MonoBehaviour
{
    public TurretBlueprint standardTurret;

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
        MngBuild.instance.SelectTurretToBuild(standardTurret);

    }

  
}
