using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitToTitle : GameOverMenuButton
{
    protected override void ClickAction()
    {
        controller.QuitToTitle();
    }
}
