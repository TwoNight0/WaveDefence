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

    // ���� ������: ĳ���� ���� ����
    private void Start()
    {
        combinations["ĳ����A"] = new List<string> { "ĳ����B", "ĳ����C" };
        combinations["ĳ����B"] = new List<string> { "ĳ����D" };
        combinations["ĳ����C"] = new List<string> { "ĳ����D", "ĳ����E" };
        combinations["ĳ����D"] = new List<string> { "ĳ����F" };

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
            resultText.text = "�Է��� ĳ���Ϳ� ���� ���� ������ �����ϴ�.";
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

        resultText.text += "= ��� ĳ����";
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
        // ���⿡�� �� ĳ���Ϳ� ���� �̹����� �ε� �Ǵ� �Ҵ��ؾ� �մϴ�.
        // ���� ��� Resources �������� �̹����� �ε��ϴ� ��� ���� ����� �� �ֽ��ϴ�.
        // �� �κ��� ������Ʈ�� ������ ���� �ٸ� �� �ֽ��ϴ�.
        // ���⿡���� ���÷� null�� ��ȯ�մϴ�.
        return null;
    }
}
