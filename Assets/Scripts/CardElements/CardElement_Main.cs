using TMPro;
using UnityEngine;

public class CardElement_Main : MonoBehaviour
{
    [HideInInspector] public CardMain Owner;
    [HideInInspector] public TMP_InputField TextName;
    public TextMeshProUGUI TextMain;    

    public virtual void StartEditing()
    {
        StaticObjects.ActualCardEditor.GetComponent<EditorPanel>().OpenEditorPanel(Owner.TMP_Name, TextMain, this);
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }    
}
