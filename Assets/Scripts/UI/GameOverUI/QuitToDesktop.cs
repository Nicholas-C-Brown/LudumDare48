using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitToDesktop : GameOverMenuButton
{
    protected override void ClickAction()
    {
        controller.QuitToDesktop();
    }
}
