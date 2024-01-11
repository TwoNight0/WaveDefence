using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Nexus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       //Debug.Log( GameManager.instance.btn_3x3[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;
        //클릭하면 1,2,3~9를 수정해야해
        //이미지랑 버튼 역할을 바꿔줘야하거든?
        //건물을 클릭하면 버튼의 상태버튼을 바꾸자 3x3 state -> 

        Debug.Log("성클릭됨");
        GameManager.instance.btn_3x3_state = GameManager.Btn_3x3_state.CLICK_NEXUS;

        //3x3 이미지들 변경 
        ChangeBtnImgbyString(0, "BtnImages/Pictoicon_Battle");
        ChangeBtnImgbyString(1, "BtnImages/Pictoicon_Battle");
        ChangeBtnImgbyString(2, "BtnImages/Pictoicon_Battle");
        ChangeBtnImgbyString(3, "BtnImages/Pictoicon_Battle");
        ChangeBtnImgbyString(4, "BtnImages/Pictoicon_Battle");
        ChangeBtnImgbyString(5, "BtnImages/Pictoicon_Battle");
        ChangeBtnImgbyString(6, "BtnImages/Pictoicon_Battle");
        ChangeBtnImgbyString(7, "BtnImages/Pictoicon_Battle");
        ChangeBtnImgbyString(8, "BtnImages/Pictoicon_Battle");



    }

    public void ChangeBtnImgbyString(int index, string imageName)
    {
        Image btnChildImg = GameManager.instance.btn_3x3[index].transform.GetChild(0).GetComponent<Image>();
        btnChildImg.sprite = Resources.Load<Sprite>(imageName);
    }
    
    

}
