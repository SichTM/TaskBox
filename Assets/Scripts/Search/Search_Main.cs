using System.Collections.Generic;
using UnityEngine;

public class Search_Main : MonoBehaviour
{
    [SerializeField] private RectTransform _tagsContainer;
    [SerializeField] private GameObject _tagInSearch;    
    public void ShowCardsByTags()
    {
        List<string> tagsToOverlap = new List<string>();

        for (int i = 0; i < _tagsContainer.childCount; i++)
        {
            var tagInSearch = _tagsContainer.GetChild(i).GetComponent<TagInSearch>();

            if (tagInSearch.IsSelected) tagsToOverlap.Add(tagInSearch.TagText.text);
        }

        for (int cardNumber = 0; cardNumber < StaticObjects.HB_Content.childCount; cardNumber++)
        {
            var tagCard = StaticObjects.HB_Content.GetChild(cardNumber);

            tagCard.gameObject.SetActive(ContainOverlaps(tagCard.GetComponent<CardMain>().Tags, tagsToOverlap));
        }
    }

    private bool ContainOverlaps(List<string> allStrings, List<string> stringsToOverlap)
    {
        bool containOverlaps = false;
        
        if (allStrings.Count <=0) return containOverlaps;
        if (stringsToOverlap.Count <= 0) return containOverlaps;        

        for (int i = 0; i < stringsToOverlap.Count; i++)
        {
            if (allStrings.Contains(stringsToOverlap[i]))
            {
                containOverlaps = true;
                break;
            }
        }

        return containOverlaps;
    }
    public void DrawAllTags()
    {
        _tagsContainer.DetachChildren();
        for (int i = 0; i < StaticObjects.ActualTagsPanel.GetComponent<EditorTagPanel>().TagList.Count; i++)
        {
            var tagInSearch = Instantiate(_tagInSearch, _tagsContainer);
            tagInSearch.GetComponent<TagInSearch>().TagText.text = StaticObjects.ActualTagsPanel.GetComponent<EditorTagPanel>().TagList[i];
        }
    }
    public void SwitchAllTags(bool activeType)
    {
        for (int i = 0; i < _tagsContainer.childCount; i++)
        {
            var child = _tagsContainer.GetChild(i).GetComponent<TagInSearch>();
            
            if (child.IsSelected != activeType) child.SwitchIndicator();
        }        
    }


}
