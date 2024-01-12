using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Nexus : MonoBehaviour
{
    private Btn3x3 btn3x3;
    
    void Start()
    {
        //Debug.Log( GameManager.instance.btn_3x3[0]);
        btn3x3 = GameManager.instance.btn3x3Obj.GetComponent<Btn3x3>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        


        Debug.Log("성클릭됨");
        GameManager.instance.btn_3x3_state = GameManager.Btn_3x3_state.CLICK_NEXUS;

        #region btn 3x3 Setting
        //0 일반 유닛 구매
        btn3x3.BtnSetting(0, 100, 1, "IMG_Nexus/AddUnit", "IMG_ETC/Gold");
        btn3x3.ChangeBtnPriceColor(0, btn3x3.colorGold);

        //1 레어 유닛 구매
        btn3x3.BtnSetting(1, 100, 2, "IMG_Nexus/AddUnit", "IMG_ETC/Gold");
        btn3x3.ChangeBtnPriceColor(1, btn3x3.colorGold);

        //2 에픽 유닛 구매
        btn3x3.BtnSetting(2, 100, 3, "IMG_Nexus/AddUnit", "IMG_ETC/Gold");
        btn3x3.ChangeBtnPriceColor(2, btn3x3.colorGold);

        //3 정원 증가
        btn3x3.BtnSetting(3, 100, 0, "IMG_Nexus/AddPopulation", "IMG_ETC/Gold");
        btn3x3.ChangeBtnPriceColor(3, btn3x3.colorGold);
        //maxpopulation 증가

        //4
        btn3x3.ClearSet(4);

        //5
        btn3x3.ClearSet(5);

        //6
        btn3x3.ClearSet(6);

        //7
        btn3x3.ClearSet(7);

        //8
        btn3x3.ClearSet(8);
        #endregion
    }





}
