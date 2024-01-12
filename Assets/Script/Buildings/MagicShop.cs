using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MagicShop : MonoBehaviour
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

        Debug.Log("������ Ŭ����");

        //���� ���������� ����
        GameManager.instance.btn_3x3_state = GameManager.Btn_3x3_state.CLICK_MAGICSHOP;

        //3x3 �̹����� ���� 
        #region btn 3x3 Setting
  
        //0 ��ų���ط� ����
        btn3x3.BtnSetting(0, 100, 0, "IMG_MagicShop/UpgradeMagicDamage", "IMG_ETC/Wood");
        btn3x3.ChangeBtnPriceColor(0, btn3x3.colorWood);

        //1 ���� ���� ����
        btn3x3.BtnSetting(1, 100, 0, "IMG_MagicShop/UpgradeSpellDamage", "IMG_ETC/Wood");
        btn3x3.ChangeBtnPriceColor(1, btn3x3.colorWood);

        //2 ��ٿ� ����
        btn3x3.BtnSetting(2, 100, 0, "IMG_MagicShop/CoolDown", "IMG_ETC/Wood");
        btn3x3.ChangeBtnPriceColor(2, btn3x3.colorWood);

        //3
        btn3x3.ClearSet(3);

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
