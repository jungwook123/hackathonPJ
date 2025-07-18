using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public enum GameState
{
    Ongoing,// 은행가는중
    OnBank,// 은행한 
    Onrunning // 도망치는중
}
public class GameManager : Singleton<GameManager>
{
    public GameObject[] heartImages;
    public int playerHeart = 3;
    public int playerMoney =100;
    public GameState gameState = GameState.Ongoing;
    public Vector2 BankPos;
    public TMP_Text MoneyText;
    public override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].SetActive(i < playerHeart);
        }
    }

    public void DiscardHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].SetActive(i < playerHeart);
        }
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

    private void FixedUpdate()
    {

        MoneyText.text = playerMoney.ToString()+"$";
    }
    
    
    
    
    
}
