using UnityEngine;

public class Store : MonoBehaviour
{
    public void Buy(int amount)
    {
        if (GameManager.Instance.playerMoney >= amount)
        {
            
        }

        return;
    }
}
