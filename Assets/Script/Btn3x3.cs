using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Btn3x3 : MonoBehaviour
{

    [HideInInspector]public Color32 colorGold;
    [HideInInspector]public Color32 colorOre;
    [HideInInspector]public Color32 colorWood;
    [HideInInspector]public Color32 colorRare;
    [HideInInspector]public Color32 colorEpic;
    [HideInInspector]public Color32 colorLagendary;

    private void Start()
    {
        colorGold = new Color32(247, 250, 41,255);
        colorOre = new Color32(117, 194, 241,255);
        colorWood = new Color32(255, 102, 0,255);
        colorRare = new Color32(79, 117, 255,255); 
        colorEpic = new Color32(255, 93, 192,255); 
        colorLagendary = new Color32(255, 178, 6,255); 
    }

    #region 3x3 ButtonActions

    //모든 버튼이 작동하기전 돈이 충분한지 

    public void Btn_1_Actions()
    {
        switch (GameManager.instance.btn_3x3_state)
        {
            case GameManager.Btn_3x3_state.NONE:
                break;
            case GameManager.Btn_3x3_state.CLICK_NEXUS:
                GameObject insMob_bat1 = Instantiate(MngShop.instance.unit_list[0], MngShop.instance.unitSpawnPoint.position, MngShop.instance.unitSpawnPoint.rotation).gameObject;
                insMob_bat1.transform.parent = GameManager.instance.activePool;
                //일반몹
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
        }
    }
    #endregion

    #region ChangeButtonDetail

    /// <summary>
    /// 메인이미지 이름으로 변경
    /// </summary>
    /// <param name="index"></param>
    /// <param name="imageName"></param>
    public void ChangeBtnImgbyString(int index, string imageName)
    {
        Image btnChildImg = GameManager.instance.ListBtn_3x3[index].transform.GetChild(0).GetComponent<Image>();
        btnChildImg.sprite = Resources.Load<Sprite>(imageName);
    }

    /// <summary>
    /// 메인이미지 색변경
    /// </summary>
    /// <param name="index"></param>
    /// <param name="color"></param>
    public void ChangeBtnImgColor(int index, Color32 color)
    {
        Image btnChildImg = GameManager.instance.ListBtn_3x3[index].transform.GetChild(0).GetComponent<Image>();
        btnChildImg.color = color;
    }

    /// <summary>
    /// 가격변경
    /// </summary>
    /// <param name="index"></param>
    /// <param name="price"></param>
    public void ChangeBtnPrice(int index, int price)
    {
        TextMeshProUGUI textPrice = GameManager.instance.ListBtn_3x3[index].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        textPrice.text = price.ToString();
    }

    /// <summary>
    /// 가격표 지우기
    /// </summary>
    /// <param name="index"></param>
    public void ChangeBtnPriceTextNone(int index)
    {
        TextMeshProUGUI textPrice = GameManager.instance.ListBtn_3x3[index].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        textPrice.text = "";
    }

    /// <summary>
    /// 가격표 색변경
    /// </summary>
    /// <param name="index"></param>
    /// <param name="color"></param>
    public void ChangeBtnPriceColor(int index, Color32 color)
    {
        TextMeshProUGUI textPrice = GameManager.instance.ListBtn_3x3[index].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        textPrice.color = color;
    }

    /// <summary>
    /// 가격표 이미지 변경
    /// </summary>
    /// <param name="index"></param>
    /// <param name="imageName"></param>
    public void ChangeBtnPriceImg(int index, string imageName)
    {
        Image btnPriceChildImg = GameManager.instance.ListBtn_3x3[index].transform.GetChild(1).GetChild(0).GetComponent<Image>();
        btnPriceChildImg.sprite = Resources.Load<Sprite>(imageName);
    }

    /// <summary>
    /// 등급에 따라 등급과 색을 변경
    /// </summary>
    /// <param name="index"></param>
    /// <param name="grade"></param>
    public void ChangeBtnGrade(int index, int grade){
        TextMeshProUGUI textGrade = GameManager.instance.ListBtn_3x3[index].transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        
        switch (grade)
        {
            case 0:
                textGrade.text = "";
                break;
            case 1:
                textGrade.text = "Common";
                textGrade.color = Color.white;
                break;
            case 2:
                textGrade.text = "Rare";
                textGrade.color = colorRare;
                break;
            case 3:
                textGrade.text = "Epic";
                textGrade.color = colorEpic;
                break;
            case 4:
                textGrade.text = "Lagendary";
                textGrade.color = colorLagendary;
                break;
        }

    }
    #endregion

    /// <summary>
    /// 올클리어
    /// </summary>
    /// <param name="index"></param>
    public void ClearSet(int index)
    {
        ChangeBtnImgbyString(index, "IMG_ETC/None");
        ChangeBtnPriceImg(index, "IMG_ETC/None");
        ChangeBtnGrade(index, 0);
        ChangeBtnPriceTextNone(index);
    }

    /// <summary>
    /// 그룹변경
    /// </summary>
    /// <param name="index"></param>
    /// <param name="price"></param>
    /// <param name="grade"></param>
    /// <param name="mainImg"></param>
    /// <param name="priceImg"></param>
    public void BtnSetting(int index, int price, int grade, string mainImg, string priceImg)
    {
        ChangeBtnImgbyString(index, mainImg);
        ChangeBtnPriceImg(index, priceImg);
        ChangeBtnPrice(index, price);
        ChangeBtnGrade(index, grade);
    }

}
