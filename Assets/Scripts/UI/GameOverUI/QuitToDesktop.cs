using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitToDesktop : MenuButton
{
    protected override void ClickAction()
    {
        controller.QuitToDesktop();
    }
}
