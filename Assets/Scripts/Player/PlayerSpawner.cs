using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [Header("Prefab & Spawn Settings")]
    public GameObject playerPrefab;       // ������ �÷��̾� ������
    public Transform spawnPosition;         // ���� ��ġ

    void Start()
    {
        Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);
    }
}