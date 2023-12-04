using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngBuild : MonoBehaviour
{
    public static MngBuild instance;

    //프리팹 배열 또는 리스트를 받야할듯
    public GameObject standardTurretPrefab;
    public TurretBlueprint turretToBuild;

    private Node selectedNode;
    public NodeUI nodeUI;

    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }

    //돈이 부족하면 false, 충분하거나 같으면 true
    public bool HasMoney
    {
        get { return PlayerStats.Money >= turretToBuild.cost; }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

}
