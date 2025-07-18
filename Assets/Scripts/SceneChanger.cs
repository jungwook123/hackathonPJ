using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneTransitionLight.Instance.TransitionToScene("URP2DSceneTemplate");
    }
}
