using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;

public class CardChecklist : CardMain
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private TextMeshProUGUI _progressText;
    private List<CardElement_Checkbox> _children = new List<CardElement_Checkbox>();

    public void RefillProgressBar()
    {
        float percent = GetCompletedChildren() / (_children.Count * 1.0f);
        _progressBar.fillAmount = percent;
        _progressText.text = Convert.ToInt32(percent * 100.0f) + "%";
    }
    public override void AddNewElement(GameObject prefab)
    {
        var element = Instantiate(prefab, ContentRectTransform).GetComponent<CardElement_Main>();
        element.Owner = gameObject.GetComponent<CardMain>();
        FixAfterEditing();

        _children.Add(element.GetComponent<CardElement_Checkbox>());
        RefillProgressBar();
    }

    private int GetCompletedChildren()
    {
        int completedCildren = 0;
        for (int i = 0; i < _children.Count; i++) if (_children[i].toggle.isOn) completedCildren++;

        return completedCildren;
    }
    public void DeleteChild(CardElement_Checkbox child)
    {
        _children.Remove(child);
        RefillProgressBar();
    }
}
