using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [Header("Prefab & Spawn Settings")]
    public GameObject playerPrefab;       // 생성할 플레이어 프리팹
    public Transform spawnPosition;         // 생성 위치

    void Start()
    {
        Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);
    }
}