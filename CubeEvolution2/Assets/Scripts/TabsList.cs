using UnityEngine;
using System.Collections.Generic;

public class TabsList : MonoBehaviour
{
    [SerializeField] private List<TabButton> _tabButtons;
    [SerializeField] private Sprite _staticImage;
    [SerializeField] private Sprite _activeImage;

    [Header("Tabs")]
    [SerializeField] private List<GameObject> _tabs;

    public void AddToList(TabButton button)
    {
        if (_tabButtons == null) _tabButtons = new List<TabButton>();
        _tabButtons.Add(button);
    }

    public void OnTabSelected(TabButton button)
    {
        ResetTabs();
        button.Background.sprite = _activeImage;
        
        TabSelect(button);
    }

    public void ResetTabs()
    {
        foreach (TabButton button in _tabButtons)
        {
            button.Background.sprite = _staticImage;
        }
    }

    private void TabSelect(TabButton button)
    {
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < _tabs.Count; i++)
        {
            if (i == index) _tabs[i].SetActive(true);
            else _tabs[i].SetActive(false);
        }
        
    }
}
