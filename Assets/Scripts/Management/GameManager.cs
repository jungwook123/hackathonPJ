using UnityEngine;

public enum GameState
{
    Ongoing,// 은행가는중
    InBank,// 은행안
    Onrunning // 도망치는중
}
public class GameManager : Singleton<GameManager>
{
    public int playerMoney =500;
    public GameState gameState = GameState.Onrunning;
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
