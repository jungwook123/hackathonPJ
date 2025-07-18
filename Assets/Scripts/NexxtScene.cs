using UnityEngine;
using UnityEngine.SceneManagement;

public class NexxtScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
