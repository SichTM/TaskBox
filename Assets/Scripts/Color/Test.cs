using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private Image _mainImage;

    private void Start()
    {
        string hex = "#5F8D4E";
        ColorUtility.TryParseHtmlString(hex, out Color newColor);
        _mainImage.color = newColor;
    }
}
