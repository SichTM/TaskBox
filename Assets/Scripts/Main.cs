using UnityEngine;

public class Main : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private GameObject _card;
    [SerializeField] private RectTransform _tagContent;
    [SerializeField] private RectTransform _background;
    [SerializeField] private GameObject _colorPanel;
    [Header("Card Editors")]
    [SerializeField] private GameObject _editor_Card_Desktop;
    [SerializeField] private GameObject _editor_Card_Mobile;
    private GameObject _actualCardPanel;
    [Header("Tags Panels")]
    [SerializeField] private GameObject _editor_TagsPanel_Desktop;
    [SerializeField] private GameObject _editor_TagsPanel_Mobile;
    [Header("Search")]
    [SerializeField] private RectTransform _HB_Content;

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            StaticObjects.ActualTagsPanel = Instantiate(_editor_TagsPanel_Mobile, _background);
            StaticObjects.ActualCardEditor = Instantiate(_editor_Card_Mobile, _background);
        }
        else
        {
            StaticObjects.ActualTagsPanel = Instantiate(_editor_TagsPanel_Desktop, _background);
            StaticObjects.ActualCardEditor = Instantiate(_editor_Card_Desktop, _background);
        }
        StaticObjects.ActualCardEditor.GetComponent<EditorPanel>().ColorPanel = _colorPanel;
        StaticObjects.ActualCardEditor.SetActive(false);
        StaticObjects.ActualTagsPanel.SetActive(false);
        StaticObjects.HB_Content = _HB_Content;
    }
    public void AddCard(GameObject prefabToSpawn)
    {
        var spawnedCard = Instantiate(prefabToSpawn, _tagContent);
        spawnedCard.GetComponent<CardMain>().EditorPanel = _actualCardPanel;
    }
}
