using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerClickHandler
{
    public TabsList tabList;
    public Image Background;

    private void Start()
    {
        Background = GetComponent<Image>();
        tabList.AddToList(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabList.OnTabSelected(this);
    }

}
