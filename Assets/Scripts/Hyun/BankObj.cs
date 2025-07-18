using UnityEngine;
using UnityEngine.SceneManagement;

public class BankObj : Object
{
    public override void Interact()
    {
        base.Interact();
        GameManager.Instance.BankPos = transform.position;
    }
}
