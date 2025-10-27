using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UIDefine;

public class MainUI : BaseUI
{
    private TextMeshProUGUI _mainText = null;

    private Button _btnTalk = null;

    private void Awake()
    {
        _uiUnique = UIUnique.MainUI;

        Transform mainTextTrans = transform.Find("MainText");
        if(mainTextTrans != null)
        {
            _mainText = mainTextTrans.GetComponentInChildren<TextMeshProUGUI>();            
        }
        SetMainText("NPC 근처로 가세요.");

        Transform btnTalkTrans = transform.Find("BtnTalk");
        if(btnTalkTrans != null)
        {
            _btnTalk = btnTalkTrans.GetComponent<Button>();
            if(_btnTalk != null)
            {
                _btnTalk.onClick.AddListener(OnClickTalk);                
                ShowTalkButton(false);
            }
        }
    }

    public void SetMainText(string text)
    {
        if(_mainText != null)
        {
            _mainText.text = text;
        }
    }

    public void ShowTalkButton(bool isShow)
    {
        if(_btnTalk != null)
        {
            _btnTalk.gameObject.SetActive(isShow);
        }
    }

    private void OnClickTalk()
    {
        //Debug.LogError("## main ui talk click ##");
    }
}
