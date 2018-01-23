using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickCommand : Command
{

    [Inject]
    public MainModel model { get; set; }

    [Inject]
    public ITrayView Tray { get; set; }

    public override void Execute()
    {
        if (!model.MouseState)
        {
            Debug.Log("=>> left MB click");
            model.MouseState = true;

            Tray.CheckClick();
        }
    }

}
