using UnityEngine;

public class DoorObj : Object
{
    public string sceneName;
    public override void Interact()
    {
        base.Interact();
        SceneTransitionLight.Instance.TransitionToScene(sceneName);
    }
}
