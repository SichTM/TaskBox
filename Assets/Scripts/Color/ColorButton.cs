using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ColorButton: MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private List<Color> _colors;
    [SerializeField] private List<Image> _otherImages;
    [SerializeField] private List<TextMeshProUGUI> _otherTexts;
    private void Awake()
    {
        _button.GetComponent<Button>().onClick.AddListener(OnClicked);
    }
    private void OnClicked()
    {
        if (_otherImages != null) ChangeColor(_otherImages, _colors);        
        if (_otherTexts != null) ChangeColor(_otherTexts, _colors);
    }
    private void ChangeColor(List<Image> images, List<Color> colors)
    {
        for (int i = 0; i<images.Count; i++ )
        {
            if (images[i] != null) images[i].color = colors[i]; 
        }
    }
    private void ChangeColor(List<TextMeshProUGUI> texts, List<Color> colors)
    {
        for (int i = 0; i < texts.Count; i++)
        {
            if (texts[i] != null) texts[i].color = colors[i];
        }
    }
}