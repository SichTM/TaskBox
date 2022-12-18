using TMPro;
using UnityEngine;

public class TagInSearch : MonoBehaviour
{
    [SerializeField] private GameObject _selectedIndicator;
    public bool IsSelected = true;
    public TMP_Text TagText;

    public void SwitchIndicator()
    {
        IsSelected = !IsSelected;
        _selectedIndicator.SetActive(IsSelected);
    }

}
