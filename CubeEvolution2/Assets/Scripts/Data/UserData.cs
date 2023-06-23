public static class UserData
{
    public static int money {get; private set;} = 120;
    public static int donate {get; private set;} = 16;
    public static int level {get; private set;}
    public static int currentExp {get; private set;}
    public static int enoughtExp {get; private set;}

    public static void AddMoney(int amount)
    {
        if (amount >= 1) money += amount;
    }

    public static void AddDonate(int amount)
    {
        if (amount >= 1) donate += amount;
    }
    
    public static void TakeMoney(int amount)
    {
        if (money >= amount) money -= amount;
    }

    public static void TakeDonate(int amount)
    {
        if (donate >= amount) donate -= amount;
    }
}
