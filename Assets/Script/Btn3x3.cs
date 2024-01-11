using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn3x3 : MonoBehaviour
{
    public void Btn_1_Actions()
    {
        switch (GameManager.instance.btn_3x3_state)
        {
            case GameManager.Btn_3x3_state.NONE:
                break;
            case GameManager.Btn_3x3_state.CLICK_NEXUS:
                GameObject insMob_bat1 = Instantiate(MngShop.instance.unit_list[0], MngShop.instance.unitSpawnPoint.position, MngShop.instance.unitSpawnPoint.rotation).gameObject;
                insMob_bat1.transform.parent = GameManager.instance.activePool;
                //ÀÏ¹Ý¸÷
                break;
            case GameManager.Btn_3x3_state.CLICK_NOMAL_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_RARE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_UNIQUE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_LEGENDARY_UNIT:
                break;
        }
    }

    public void Btn_2_Actions()
    {
        switch (GameManager.instance.btn_3x3_state)
        {
            case GameManager.Btn_3x3_state.NONE:
                break;
            case GameManager.Btn_3x3_state.CLICK_NEXUS:
                GameObject insMob_bat1 = Instantiate(MngShop.instance.unit_list[1], MngShop.instance.unitSpawnPoint.position, MngShop.instance.unitSpawnPoint.rotation).gameObject;
                insMob_bat1.transform.parent = GameManager.instance.activePool;
                break;
            case GameManager.Btn_3x3_state.CLICK_NOMAL_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_RARE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_UNIQUE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_LEGENDARY_UNIT:
                break;

        }
    }
    public void Btn_3_Actions()
    {
        switch (GameManager.instance.btn_3x3_state)
        {
            case GameManager.Btn_3x3_state.NONE:
                break;
            case GameManager.Btn_3x3_state.CLICK_NEXUS:
                break;
            case GameManager.Btn_3x3_state.CLICK_NOMAL_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_RARE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_UNIQUE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_LEGENDARY_UNIT:
                break;
        }
    }
    public void Btn_4_Actions()
    {
        switch (GameManager.instance.btn_3x3_state)
        {
            case GameManager.Btn_3x3_state.NONE:
                break;
            case GameManager.Btn_3x3_state.CLICK_NEXUS:
                break;
            case GameManager.Btn_3x3_state.CLICK_NOMAL_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_RARE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_UNIQUE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_LEGENDARY_UNIT:
                break;
        }
    }
    public void Btn_5_Actions()
    {
        switch (GameManager.instance.btn_3x3_state)
        {
            case GameManager.Btn_3x3_state.NONE:
                break;
            case GameManager.Btn_3x3_state.CLICK_NEXUS:
                break;
            case GameManager.Btn_3x3_state.CLICK_NOMAL_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_RARE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_UNIQUE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_LEGENDARY_UNIT:
                break;
        }
    }
    public void Btn_6_Actions()
    {
        switch (GameManager.instance.btn_3x3_state)
        {
            case GameManager.Btn_3x3_state.NONE:
                break;
            case GameManager.Btn_3x3_state.CLICK_NEXUS:
                break;
            case GameManager.Btn_3x3_state.CLICK_NOMAL_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_RARE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_UNIQUE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_LEGENDARY_UNIT:
                break;
        }
    }
    public void Btn_7_Actions()
    {
        switch (GameManager.instance.btn_3x3_state)
        {
            case GameManager.Btn_3x3_state.NONE:
                break;
            case GameManager.Btn_3x3_state.CLICK_NEXUS:
                break;
            case GameManager.Btn_3x3_state.CLICK_NOMAL_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_RARE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_UNIQUE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_LEGENDARY_UNIT:
                break;
        }
    }

    public void Btn_8_Actions()
    {
        switch (GameManager.instance.btn_3x3_state)
        {
            case GameManager.Btn_3x3_state.NONE:
                break;
            case GameManager.Btn_3x3_state.CLICK_NEXUS:
                break;
            case GameManager.Btn_3x3_state.CLICK_NOMAL_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_RARE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_UNIQUE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_LEGENDARY_UNIT:
                break;
        }
    }
    public void Btn_9_Actions()
    {
        switch (GameManager.instance.btn_3x3_state)
        {
            case GameManager.Btn_3x3_state.NONE:
                break;
            case GameManager.Btn_3x3_state.CLICK_NEXUS:
                break;
            case GameManager.Btn_3x3_state.CLICK_NOMAL_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_RARE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_UNIQUE_UNIT:
                break;
            case GameManager.Btn_3x3_state.CLICK_LEGENDARY_UNIT:
                break;
        }
    }


}
