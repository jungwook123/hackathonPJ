// PlayerInteraction.cs
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject promptUI;

    private Iinteractable currentInteractable;

    void Start()
    {
        promptUI.SetActive(false);
    }

    void Update()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.F))
            currentInteractable.Interact();
    }

    // 2D 트리거 진입
    void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<Iinteractable>();
        if (interactable != null)
        {
            currentInteractable = interactable;
            promptUI.SetActive(true);
        }
    }

    // 2D 트리거 이탈
    void OnTriggerExit2D(Collider2D other)
    {
        var interactable = other.GetComponent<Iinteractable>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
            promptUI.SetActive(false);
            interactable.HideUI();
            
        }
    }
}