using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int playerMoney =500;
    
    public override void Awake()
    {
        base.Awake();
    }

    public void AddMoney(int amount)
    {
        playerMoney += amount;
    }

    public void DiscountMoney(int amount)
    {
        playerMoney -= amount;
    }

    public void EndRaid()
    {
        
    }
    
    
    
    
    
}
