using TMPro;
using UnityEngine;

public class TagInCard : MonoBehaviour
{
    [HideInInspector] public CardMain CardMain;
    public TMP_Text TagText; 
    public void DestroySelf()
    {
        CardMain?.RemoveTag(TagText.text);
        Destroy(gameObject);
    }    
}
