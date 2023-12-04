using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngBuild : MonoBehaviour
{
    public static MngBuild instance;

    //������ �迭 �Ǵ� ����Ʈ�� �޾��ҵ�
    public GameObject standardTurretPrefab;
    public TurretBlueprint turretToBuild;

    private Node selectedNode;
    public NodeUI nodeUI;

    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }

    //���� �����ϸ� false, ����ϰų� ������ true
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
