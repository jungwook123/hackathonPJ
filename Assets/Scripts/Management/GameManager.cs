using UnityEngine;

public enum GameState
{
    Ongoing,// 은행가는중
    OnBank,// 은행한 
    Onrunning // 도망치는중
}
public class GameManager : Singleton<GameManager>
{
    public int playerHeart = 3;
    public int playerMoney =100;
    public GameState gameState = GameState.Ongoing;
    public Vector2 BankPos;
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
