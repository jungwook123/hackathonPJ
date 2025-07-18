using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    [Header("총알 설정")]
    public GameObject bulletPrefab;
    public Transform firePoint;       // 총구 위치
    public float bulletSpeed = 10f;
    public int maxAmmo = 13;
    private int currentAmmo;
    private float reloadTime = 1.0f;
    private bool isReloading = false;

    [Header("기타")]
    private Camera mainCam;
    public Transform player; // ✅ 플레이어 트랜스폼
    public float radius = 0.5f; // ✅ 플레이어 중심에서의 거리
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        mainCam = Camera.main;
        currentAmmo = maxAmmo;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        RotateGunToMouse();
        PositionGunAroundPlayer();

        if (isReloading) return;

        RotateGunToMouse();

        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            Fire();
            CamManager.instance.Shake(1,0.2f);
        }

        if (Input.GetKeyDown(KeyCode.R)) // R키로 재장전
        {
            StartCoroutine(Reload());
        }
    }

    void RotateGunToMouse()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle > 90 || angle < -90)
            spriteRenderer.flipY = true;
        else
            spriteRenderer.flipY = false;
        spriteRenderer.flipX = true;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void PositionGunAroundPlayer()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 dir = (mousePos - player.position).normalized;
        transform.position = player.position + dir * radius;
    }

    void Fire()
    {
        Quaternion bulletRotation = transform.rotation * Quaternion.Euler(0, 0, 90f);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, bulletRotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = -bullet.transform.up * bulletSpeed;
        }

        currentAmmo--;
        Debug.Log("발사! 남은 탄약: " + currentAmmo);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Destroy(gameObject); // 총알 제거
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("재장전 중...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("재장전 완료! 탄약: " + currentAmmo);
    }

}
