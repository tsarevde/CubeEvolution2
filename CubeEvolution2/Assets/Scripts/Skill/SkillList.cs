using UnityEngine;

public class SkillList : MonoBehaviour
{
    public static SkillData[] SkillsList {get; private set;}

    public void Awake()
    {
        SkillsList = Resources.LoadAll<SkillData>("SkillData");
    }
}
