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
        UI.SetActive(true);
    }

    public void HideUI()
    {
        UI.SetActive(false);
    }

}
