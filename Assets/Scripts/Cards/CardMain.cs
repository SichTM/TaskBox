using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class CardMain : MonoBehaviour
{
    [HideInInspector] public GameObject EditorPanel;
    public TMP_InputField TMP_Name;
    [Header("Content")]
    [SerializeField] protected GameObject Content;
    [SerializeField] protected RectTransform ContentRectTransform;
    [Header("Tags")]
    [SerializeField] private GameObject _tagPrefab;
    [SerializeField] private GameObject _contentForTags;
    [SerializeField] protected RectTransform ContentForTagsRectTransform;
    public List<string> Tags;    

    public virtual void AddNewElement(GameObject prefab)
    {
        var element = Instantiate(prefab, ContentRectTransform).GetComponent<CardElement_Main>();
        element.Owner = this;
        FixAfterEditing();        
    }
    private IEnumerator FixSize()
    {
        ContentSizeFitter contentSizeFitter = Content.GetComponent<ContentSizeFitter>();

        contentSizeFitter.enabled = false;
        yield return new WaitForSeconds(0.1f);
        contentSizeFitter.enabled = true;

        Content.GetComponent<VerticalLayoutGroup>().childForceExpandWidth = false;
        yield return new WaitForSeconds(0.1f);
        Content.GetComponent<VerticalLayoutGroup>().childForceExpandWidth = true;
    }
    public void FixAfterEditing()
    {
        StartCoroutine(FixSize());
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    public void AddNewTag(string tagName, Color tagColor)
    {
        var tag = Instantiate(_tagPrefab, ContentForTagsRectTransform);
        tag.GetComponent<Image>().color = tagColor;
        tag.GetComponent<TagInCard>().TagText.text = tagName;
        tag.GetComponent<TagInCard>().CardMain = this; 
        Tags.Add(tagName);
    }

    public void RemoveTag(string tagName)
    {
        Tags.Remove(tagName);
    }
    public void OpenTagsEditorPanel() => StaticObjects.ActualTagsPanel.GetComponent<EditorTagPanel>().OpenEditorTagPanel(this);        

}
