using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class SceneTransitionLight : MonoBehaviour
{
    public static SceneTransitionLight Instance { get; private set; }

    public Light2D sceneLight;               // 연결된 Spot Light 2D
    public float transitionTime = 1.5f;      // 페이드 시간

    private bool isTransitioning = false;

    void Awake()
    {
        // 싱글톤 생성
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);  // 씬 이동 시 파괴 방지
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬 이동 후 새 Light 찾아 연결
        Light2D foundLight = FindAnyObjectByType<Light2D>();
        if (foundLight != null)
        {
            sceneLight = foundLight;
            StartCoroutine(FadeInLight());
        }
    }

    public void TransitionToScene(string sceneName)
    {
        if (!isTransitioning)
            StartCoroutine(TransitionSceneCoroutine(sceneName));
    }

    private IEnumerator TransitionSceneCoroutine(string sceneName)
    {
        isTransitioning = true;

        yield return StartCoroutine(FadeOutLight());

        yield return new WaitForSeconds(0.2f); // 부드러운 전환을 위한 딜레이

        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeOutLight()
    {
        float startIntensity = sceneLight.intensity;
        float startRadius = sceneLight.pointLightOuterRadius;

        for (float t = 0; t < transitionTime; t += Time.deltaTime)
        {
            float progress = 1 - (t / transitionTime);
            sceneLight.intensity = startIntensity * progress;
            sceneLight.pointLightOuterRadius = startRadius * progress;
            yield return null;
        }

        sceneLight.intensity = 0;
        sceneLight.pointLightOuterRadius = 0;
    }

    private IEnumerator FadeInLight()
    {
        float targetIntensity = 1f;
        float targetRadius = 5f;

        sceneLight.intensity = 0;
        sceneLight.pointLightOuterRadius = 0;

        for (float t = 0; t < transitionTime; t += Time.deltaTime)
        {
            float progress = t / transitionTime;
            sceneLight.intensity = targetIntensity * progress;
            sceneLight.pointLightOuterRadius = targetRadius * progress;
            yield return null;
        }

        sceneLight.intensity = targetIntensity;
        sceneLight.pointLightOuterRadius = targetRadius;

        isTransitioning = false;
    }
}
