using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class EditorTagPanel : MonoBehaviour
{
    private CardMain _childCard;
    [HideInInspector] public List<string> TagList = new List<string>();
    [SerializeField] private TMP_InputField _tagInput;
    [SerializeField] private Color _defaultColor;
    [Header("Tags")]
    [SerializeField] private GameObject _tagInEditor;
    [SerializeField] private RectTransform _tagsContainer;
    public void OpenEditorTagPanel(CardMain cardMain)
    {
        _childCard = cardMain;
        SwitchEditorPanel();
        DrawAllTags();        
    }
    public void OnEndEdit()
    {
        AddEditorTag();
        _tagInput.text = string.Empty;
    }
    public void AddCardTag(string tagName)
    {
        _childCard.AddNewTag(tagName, _defaultColor);        
        SwitchEditorPanel();
    }
    public void AddEditorTag()
    {
        if (_tagInput.text != string.Empty)
        {
            TagList.Add(_tagInput.text);
            GameObject tagInEditor = Instantiate(_tagInEditor, _tagsContainer);
            tagInEditor.GetComponent<TagInEditor>().TagText.text = _tagInput.text;
        }            
    }
    public void RemoveEditorTag(string tagName)
    {
        TagList.Remove(tagName);
    }
    private void SwitchEditorPanel()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    private void DrawAllTags()
    {
        _tagsContainer.DetachChildren();
        for (int i = 0; i < TagList.Count; i++)
        {
            var tagInEditor = Instantiate(_tagInEditor, _tagsContainer);
            tagInEditor.transform.GetChild(0).GetComponent<TMP_Text>().text = TagList[i];
        }
    }
}
