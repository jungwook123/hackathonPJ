using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IHitable
{
    [SerializeField] private int health = 3;
    private Collider2D playerCollider;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Hit()
    {
        health--;
        StartCoroutine(anfl());
        if (health <= 0)
        {
            
        }

        GameManager.Instance.playerMoney -= 10;
    }

    IEnumerator anfl()
    {
        playerCollider.enabled = false;

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
        playerCollider.enabled = true;
    }
    
}
