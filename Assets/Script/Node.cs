using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    //----Color
    public Color hoverColor;
    private Color startColor;
    public Color UnableColor;

    public TurretBlueprint blueprint;  

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;

    public Vector3 offset;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        //���ӿ�����Ʈ �ڿ������� ȣ�����°� �����ʰ� �ϱ� ���� 
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (MngBuild.instance.CanBuild)
        {
            return;
        }

        if (MngBuild.instance.HasMoney)
        {
            //��ü ����ٲٱ�
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = UnableColor;
        }
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(turret != null)
        {
            Debug.Log("�̹� �ǹ� �Ǵ� ������ ��ġ�Ǿ��ֽ��ϴ�");
            return;
        }

        if (!MngBuild.instance.CanBuild)
        {
            return;
        }
        
        BuildTurret(blueprint);
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + offset;

    }
    public void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("���� ���ڶ�");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;


        //���� ����Ʈ

        Debug.Log("Turret build, Money left: " + PlayerStats.Money);
    }
}
