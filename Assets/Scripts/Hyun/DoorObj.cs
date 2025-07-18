using UnityEngine;

public class DoorObj : Object
{
    public string sceneName;
    public GameState gameState;
    public override void Interact()
    {
        base.Interact();
        SceneTransitionLight.Instance.TransitionToScene(sceneName);
        GameManager.Instance.gameState = gameState;
    }
}
