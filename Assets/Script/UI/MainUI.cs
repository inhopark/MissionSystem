using TMPro;
using UnityEngine;
using static UIDefine;

public class MainUI : BaseUI
{
    private TextMeshProUGUI _mainText = null;

    private void Awake()
    {
        _uiUnique = UIUnique.MainUI;

        _mainText = transform.GetComponentInChildren<TextMeshProUGUI>();
        SetMainText("NPC 근처로 가세요.");
    }

    public void SetMainText(string text)
    {
        if(_mainText != null)
        {
            _mainText.text = text;
        }
    }
}
