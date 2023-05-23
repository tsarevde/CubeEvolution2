using UnityEngine;

public class CharacterInfoBlockUI : CharacterSelection
{
    [SerializeField] private GameObject _blockInfo;

    private void OnEnable()
    {
        TabsList.onEnableBlock += EnableBlock;
        TabsList.onDisableBlock += DisableBlock;

        DisableBlock();
    }

    private void OnDisable()
    {
        TabsList.onEnableBlock -= EnableBlock;
        TabsList.onDisableBlock -= DisableBlock;
    }

    private void EnableBlock()
    {
        _blockInfo.SetActive(true);
    }
    private void DisableBlock()
    {
        _blockInfo.SetActive(false);
    }
}
