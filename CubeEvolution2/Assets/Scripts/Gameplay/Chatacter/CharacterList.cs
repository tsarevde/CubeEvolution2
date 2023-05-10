using UnityEngine;

public abstract class CharacterList : MonoBehaviour
{
    public Character[] _character {get; private set;}

    public void Awake()
    {
        _character = Resources.LoadAll<Character>("Characters");
    }
}
