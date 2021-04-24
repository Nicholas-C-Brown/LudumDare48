using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MenuButton
{

    protected override void ClickAction()
    {
        controller.Restart();
    }
}
