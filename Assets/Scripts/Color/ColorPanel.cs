using UnityEngine;

public class ColorPanel : MonoBehaviour
{
    public void SwitchColorPanel(GameObject colorPanel)
    {
        colorPanel.SetActive(!colorPanel.activeSelf);
    }    
}
