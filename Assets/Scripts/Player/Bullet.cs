using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("적 적중!");
            Destroy(gameObject); // 총알 삭제
        }
        if (other.CompareTag("Safe"))  // 금고의 태그가 "Safe"라면
        {
            Safe safe = other.GetComponent<Safe>();
            safe.OnDamaged();
            Destroy(gameObject); // 총알 제거
        }
    }
}
