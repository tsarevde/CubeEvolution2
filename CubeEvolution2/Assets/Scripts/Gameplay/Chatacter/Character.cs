using UnityEngine;

[CreateAssetMenu(fileName = "character", menuName = "Character")]
public class Character : ScriptableObject
{
    [SerializeField] private string characterName;
    [SerializeField] private string caharacterDescription;
    [SerializeField] private int unlockLevel;
    [SerializeField] private int unlockPrice;
    [SerializeField] private GameObject characterModel;

    public string Name { get => characterName; }
    public string Description { get => caharacterDescription; }
    public int UnlockLevel { get => unlockLevel; }
    public int UnlockPrice { get => unlockPrice; }
    public GameObject Model { get => characterModel; }
}
