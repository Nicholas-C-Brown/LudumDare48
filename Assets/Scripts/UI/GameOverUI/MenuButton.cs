using UnityEngine;

public abstract class MenuButton : MonoBehaviour
{

    [SerializeField]
    protected GameController controller;

    [SerializeField]
    private float delay = 1f;

    public void OnClick()
    {
        CodeMonkey.Utils.FunctionTimer.Create(() => ClickAction(), delay);
    }

    protected abstract void ClickAction();

}
