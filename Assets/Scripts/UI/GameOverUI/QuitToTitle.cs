using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitToTitle : MenuButton
{
    protected override void ClickAction()
    {
        controller.QuitToTitle();
    }
}
