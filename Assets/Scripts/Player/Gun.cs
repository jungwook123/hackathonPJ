using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("�Ѿ� ����")]
    public GameObject bulletPrefab;
    public Transform firePoint;       // �ѱ� ��ġ
    public float bulletSpeed = 10f;
    public int maxAmmo = 13;
    private int currentAmmo;

    [Header("��Ÿ")]
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        RotateGunToMouse();

        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            Fire();
        }
    }

    void RotateGunToMouse()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = bullet.transform.right * bulletSpeed;
        }

        currentAmmo--;
        Debug.Log("�߻�! ���� ź��: " + currentAmmo);
    }
}
