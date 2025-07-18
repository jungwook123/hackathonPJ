using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class DotweenSceneChanger : MonoBehaviour
{
    public static DotweenSceneChanger Instance;

    [Header("Fade Settings")]
    [SerializeField] private Image fadeImage; // 검정 이미지 (UI로 화면 덮기)
    [SerializeField] private float fadeDuration = 0.5f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadSceneWithFade(string sceneName)
    {
        StartCoroutine(FadeAndSwitchScene(sceneName));
    }

    private System.Collections.IEnumerator FadeAndSwitchScene(string sceneName)
    {
        // 1. 페이드 아웃
        fadeImage.raycastTarget = true;
        yield return fadeImage.DOFade(1, fadeDuration).WaitForCompletion();

        // 2. 씬 비동기 로드
        yield return SceneManager.LoadSceneAsync(sceneName);

        // 3. 페이드 인
        yield return fadeImage.DOFade(0, fadeDuration).WaitForCompletion();
        fadeImage.raycastTarget = false;
    }
}
