using TMPro;
using UnityEngine;

public class EditorPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField _textName; 
    [SerializeField] private TMP_InputField _textMain;
    [HideInInspector] public GameObject ColorPanel;
    
    private TMP_InputField TMP_Name;
    private TMP_Text TMP_Main;
    private CardElement_URL CE_URL;
    private CardElement_Main Element;
    public void OpenEditorPanel(TMP_InputField textName, TMP_Text textMain, CardElement_Main element)
    {
        ColorPanel.SetActive(false);
        gameObject.SetActive(true);
        Element = element;
        
        TMP_Name = textName;
        TMP_Main = textMain;
        
        _textName.text = textName.text;        
        _textMain.text = textMain.text;
    }
    public void OpenEditorPanel(CardElement_URL E_URL, TMP_Text description)
    {
        ColorPanel.SetActive(false);
        gameObject.SetActive(true);
        Element = E_URL;

        CE_URL = E_URL;
        TMP_Main = description;

        _textName.text = E_URL.URL;
        _textMain.text = description.text;
    }

    public void CloseAndSaveChanges()
    {
        if (CE_URL == null) {
            TMP_Name.text = _textName.text;
        } else {
            CE_URL.URL = _textName.text;
        }
        TMP_Main.text = _textMain.text;

        Element.Owner.FixAfterEditing();
        CloseWithoutChanges();
    } 
    public void CloseWithoutChanges()
    {
        _textMain.text = "";
        _textName.text = "";
        CE_URL = null;
        gameObject.SetActive(false);
    }
    public void CloseAndDeliteElement()
    {
        gameObject.SetActive(false);
        Element.DestroySelf();        
    }
}
