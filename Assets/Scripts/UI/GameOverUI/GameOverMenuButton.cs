using UnityEngine;

public abstract class GameOverMenuButton : MonoBehaviour
{

    [SerializeField]
    protected GameController controller;

    public void OnClick()
    {
        CodeMonkey.Utils.FunctionTimer.Create(() => ClickAction(), 1f);
    }

    protected abstract void ClickAction();

}
