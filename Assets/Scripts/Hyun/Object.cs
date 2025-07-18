using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public abstract class Object : MonoBehaviour, Iinteractable
{
    public GameObject UI;
    protected virtual void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }


    public virtual void Interact()
    {
        if (UI == null) return;
        UI.SetActive(true);
    }

    public void HideUI()
    {
        if (UI == null) return;
        UI.SetActive(false);
    }

}
