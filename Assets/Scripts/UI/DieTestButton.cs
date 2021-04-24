using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTestButton : MenuButton
{
    public MovePlayer player;

    protected override void ClickAction()
    {
        player.Die();
    }
}
