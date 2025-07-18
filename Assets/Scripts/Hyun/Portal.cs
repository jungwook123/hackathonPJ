using UnityEngine;

public class Portal : Object
{
    public override void Interact()
    {
        base.Interact();
        if(GameManager.Instance.gameState != GameState.Onrunning) return;
        SceneTransitionLight.Instance.TransitionToScene("Home 1");
    }
}
