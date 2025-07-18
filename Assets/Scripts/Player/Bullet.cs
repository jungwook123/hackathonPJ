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
            Debug.Log("�� ����!");
            Destroy(gameObject); // �Ѿ� ����
        }
        if (other.CompareTag("Safe"))  // �ݰ��� �±װ� "Safe"���
        {
            Safe safe = other.GetComponent<Safe>();
            safe.OnDamaged();
            Destroy(gameObject); // �Ѿ� ����
        }
    }
}
