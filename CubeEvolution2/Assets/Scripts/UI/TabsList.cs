using System;
using UnityEngine;
using System.Collections.Generic;

public class TabsList : MonoBehaviour
{
    [SerializeField] private List<TabButton> _tabButtons;
    [SerializeField] private Sprite _staticImage;
    [SerializeField] private Sprite _activeImage;
    public static Action onEnableBlock;
    public static Action onDisableBlock;

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
            if (i == index)
            {
                _tabs[i].SetActive(true);
                
                if (i != 0) onEnableBlock?.Invoke();
                else onDisableBlock?.Invoke();
            }
            else _tabs[i].SetActive(false);
        }
    }
}
