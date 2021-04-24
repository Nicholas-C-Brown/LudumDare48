using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MenuButton
{

    protected override void ClickAction()
    {
        controller.PlayGame();
    }
}