using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpGradeShop : MonoBehaviour
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

        Debug.Log("강화소 클릭됨");

        //상태 마법샵으로 변경
        GameManager.instance.btn_3x3_state = GameManager.Btn_3x3_state.CLICK_UPGRADESHOP;

        #region btn 3x3 Setting

        //0 일반 유닛 강화
        btn3x3.BtnSetting(0, 100, 1, "IMG_UpGradeShop/UpGradeClass", "IMG_ETC/Ore");
        btn3x3.ChangeBtnPriceColor(0, btn3x3.colorOre);

        //1 레어 유닛 강화
        btn3x3.BtnSetting(1, 100, 2, "IMG_UpGradeShop/UpGradeClass", "IMG_ETC/Ore");
        btn3x3.ChangeBtnPriceColor(1, btn3x3.colorOre);

        //2 에픽 유닛 강화
        btn3x3.BtnSetting(2, 100, 3, "IMG_UpGradeShop/UpGradeClass", "IMG_ETC/Ore");
        btn3x3.ChangeBtnPriceColor(2, btn3x3.colorOre);

        //3 공격속도 강화
        btn3x3.BtnSetting(3, 100, 0, "IMG_UpGradeShop/AttackSpeed", "IMG_ETC/Ore");
        btn3x3.ChangeBtnPriceColor(3, btn3x3.colorOre);

        //4 방어력 관통력 강화
        btn3x3.BtnSetting(4, 100, 0, "IMG_UpGradeShop/UpGradePierce", "IMG_ETC/Ore");
        btn3x3.ChangeBtnPriceColor(4, btn3x3.colorOre);

        //5
        btn3x3.BtnSetting(5, 100, 0, "IMG_UpGradeShop/Critical", "IMG_ETC/Ore");
        btn3x3.ChangeBtnPriceColor(5, btn3x3.colorOre);

        //6
        btn3x3.ClearSet(6);

        //7
        btn3x3.ClearSet(7);

        //8
        btn3x3.ClearSet(8);
        #endregion


      



    }


    
    

}
