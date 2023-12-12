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

    public bool isBuild = false;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;

    public Vector3 offset;

    public Node Node_top;
    public Node Node_bot;
    public Node Node_left;
    public Node Node_right;
    
    

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        if (gameObject.name == "Node 44") {
            Debug.Log(Node_right.name);
            Debug.Log(Node_left.name);
        }
        

    }

    private void OnMouseEnter()
    {
        //게임오브젝트 뒤에있으면 호버상태가 되지않게 하기 위함 
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (MngBuild.instance.CanBuild)
        {
            return;
        }

        if (MngBuild.instance.HasMoney)
        {
            //객체 색상바꾸기
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
            Debug.Log("이미 건물 또는 유잇이 배치되어있습니다");
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
            Debug.Log("돈이 모자람");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;


        //빌드 이펙트

        Debug.Log("Turret build, Money left: " + PlayerStats.Money);
    }
}
