using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IHitable
{
    [SerializeField] private int health = 3;
    private Collider2D playerCollider;
    private SpriteRenderer spriteRenderer;
    private bool isInvincible = false;
    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Hit()
    {
        if (isInvincible) return;
        GameManager.Instance.playerHeart--;
        GameManager.Instance.DiscardHearts();
        StartCoroutine(anfl());
        GameManager.Instance.playerMoney -= 10;

        if (health <= 0)
        {
            // 사망 처리 로직
        }
    }

    IEnumerator anfl()
    {
        isInvincible = true;
        health--;

        Color originalColor = spriteRenderer.color;
        Color blackColor = Color.black;

        float duration = 2f;
        float blinkInterval = 0.2f;
        float timer = 0f;

        while (timer < duration)
        {
            spriteRenderer.color = (spriteRenderer.color == originalColor) ? blackColor : originalColor;
            yield return new WaitForSeconds(blinkInterval);
            timer += blinkInterval;
        }

        spriteRenderer.color = originalColor;
        isInvincible = false;
    }
}
