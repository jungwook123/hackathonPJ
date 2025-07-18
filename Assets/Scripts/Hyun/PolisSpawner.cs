using UnityEngine;

public class PolisSpawner : MonoBehaviour
{
    public GameObject polisPrefab;
    private void Start()
    {
        Instantiate(polisPrefab, transform.position, Quaternion.identity);
    }
}
