using UnityEngine;

public class CardElement_URL : CardElement_Main
{
    [HideInInspector] public string URL = "https://president.gov.by/en";
    public void OpenURL()
    {
        Application.OpenURL(URL);
    }
    public override void StartEditing()
    {
        StaticObjects.ActualCardEditor.GetComponent<EditorPanel>().OpenEditorPanel(this, TextMain);
    }
}
