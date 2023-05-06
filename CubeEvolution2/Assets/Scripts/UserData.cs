using UnityEngine;

public class UserData : MonoBehaviour
{
    public static int money {get; private set;}
    public static int donate {get; private set;}
    public static int level {get; private set;}
    public static int currentExp {get; private set;}
    public static int enoughtExp {get; private set;}
    public static int selectTypeCube {get; private set;}

    public static UserData script;

    private void Awake() 
    {
        UserData.script = this;
        
        money = 82;
        donate = 55;
        level = 1;
        currentExp = 1;
        enoughtExp = 5;

        selectTypeCube = 0;
    }
}
