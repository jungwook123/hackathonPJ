using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    public Image[] heartImages;
    public TMP_Text moneyText;

    void Update()
    {
        UpdateHearts(GameManager.Instance.playerHeart);
        //ammoText.text = $"{playerGun.currentAmmo : ∞}";
    }

    void UpdateHearts(int heartCount)
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].enabled = (i < heartCount);
        }
    }
}