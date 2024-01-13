using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Search_Combination : MonoBehaviour
{
    public Image characterImage;
    public Image[] requiredCharacterImages;
    public Text resultText;

    private Dictionary<string, List<string>> combinations = new Dictionary<string, List<string>>();
    private string currentCharacter;

    // 예시 데이터: 캐릭터 조합 정보
    private void Start()
    {
        combinations["캐릭터A"] = new List<string> { "캐릭터B", "캐릭터C" };
        combinations["캐릭터B"] = new List<string> { "캐릭터D" };
        combinations["캐릭터C"] = new List<string> { "캐릭터D", "캐릭터E" };
        combinations["캐릭터D"] = new List<string> { "캐릭터F" };

        resultText.text = "";
        ClearCharacterImages();
    }

    public void SearchCombination(string character)
    {
        if (combinations.ContainsKey(character))
        {
            currentCharacter = character;
            List<string> requiredCharacters = combinations[character];
            DisplayCombination(character, requiredCharacters);
        }
        else
        {
            resultText.text = "입력한 캐릭터에 대한 조합 정보가 없습니다.";
            ClearCharacterImages();
        }
    }

    private void DisplayCombination(string character, List<string> requiredCharacters)
    {
        resultText.text = $"{character} + ";

        for (int i = 0; i < requiredCharacterImages.Length; i++)
        {
            if (i < requiredCharacters.Count)
            {
                requiredCharacterImages[i].gameObject.SetActive(true);
                requiredCharacterImages[i].sprite = GetCharacterSprite(requiredCharacters[i]);
                resultText.text += $"{requiredCharacters[i]} ";
            }
            else
            {
                requiredCharacterImages[i].gameObject.SetActive(false);
            }
        }

        resultText.text += "= 결과 캐릭터";
    }

    private void ClearCharacterImages()
    {
        characterImage.sprite = null;
        foreach (var image in requiredCharacterImages)
        {
            image.sprite = null;
            image.gameObject.SetActive(false);
        }
    }

    private Sprite GetCharacterSprite(string character)
    {
        // 여기에서 각 캐릭터에 대한 이미지를 로드 또는 할당해야 합니다.
        // 예를 들어 Resources 폴더에서 이미지를 로드하는 방법 등을 사용할 수 있습니다.
        // 이 부분은 프로젝트의 구조에 따라 다를 수 있습니다.
        // 여기에서는 예시로 null을 반환합니다.
        return null;
    }
}
