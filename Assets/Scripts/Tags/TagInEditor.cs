using TMPro;
using UnityEngine;

public class TagInEditor : MonoBehaviour
{
    public TMP_Text TagText;
    private EditorTagPanel _actualTagPanel;
    private void Start()
    {
        _actualTagPanel = StaticObjects.ActualTagsPanel.GetComponent<EditorTagPanel>();
    }
    public void AddCardTag()
    {
        _actualTagPanel.AddCardTag(TagText.text);        
    }
    public void DeleteSelf()
    {
        _actualTagPanel.RemoveEditorTag(TagText.text);
        Destroy(gameObject);
    }
}
