using UnityEngine;
using System.Collections;

public class Safe : MonoBehaviour
{
    public GameObject coinPrefab;
    public float dropDuration = 0.3f;  // �̵� �ð� (��)

    public void DropCoins()
    {
        int coinCount = Random.Range(1, 4);
        for (int i = 0; i < coinCount; i++)
        {
            // ���� ����
            GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);

            // ���� ����� �Ÿ� ����
            Vector2 randomDir = Random.insideUnitCircle.normalized;
            float randomDistance = Random.Range(1.5f, 3f);
            Vector3 targetPos = transform.position + (Vector3)(randomDir * randomDistance);

            // �ڷ�ƾ���� �̵� ó��
            StartCoroutine(MoveCoin(coin, targetPos, dropDuration));
        }
    }

    IEnumerator MoveCoin(GameObject coin, Vector3 targetPos, float duration)
    {
        Vector3 start = coin.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            coin.transform.position = Vector3.Lerp(start, targetPos, t);
            yield return null;
        }

        // ��Ȯ�� ��ġ ����
        coin.transform.position = targetPos;
    }

    public void OnDamaged()
    {
        DropCoins();
    }
}
