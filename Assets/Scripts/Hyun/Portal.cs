using UnityEngine;

public class Portal : Object
{
    public override void Interact()
    {
        base.Interact();
        SceneTransitionLight.Instance.TransitionToScene("Home");
    }
}
