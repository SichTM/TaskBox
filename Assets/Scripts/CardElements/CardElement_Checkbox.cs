using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardElement_Checkbox : CardElement_Main
{
    [Header("Toggle")]
    public Toggle toggle;
    [SerializeField] private Image _toggleImage;
    [SerializeField] private Sprite _activeSprite;
    [Space]
    [Header("Colors")]
    [SerializeField] private Color _normalTextColor;
    [SerializeField] private Color _thickTextColor;

    public void OnToggleSwitched()
    {
        Owner?.GetComponent<CardChecklist>().RefillProgressBar();
        if (Owner != null) SwitchObjectImage();

        if (toggle.isOn){
            TextMain.fontStyle = FontStyles.Strikethrough;
            TextMain.color = _thickTextColor;
        } else {
            TextMain.fontStyle = FontStyles.Normal;
            TextMain.color = _normalTextColor;
        }
    }
    public void SwitchObjectImage()
    {
        if (_toggleImage.sprite == _activeSprite) {
            _toggleImage.sprite = null;
        } else {
            _toggleImage.sprite = _activeSprite;
        }
    }
    private void OnDestroy()
    {
        Owner?.GetComponent<CardChecklist>().DeleteChild(gameObject.GetComponent<CardElement_Checkbox>());
    }
}
