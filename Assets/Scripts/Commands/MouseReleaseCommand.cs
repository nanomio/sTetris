using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseReleaseCommand : Command
{

    [Inject]
    public MainModel model { get; set; }

    [Inject]
    public ITrayView trayView { get; private set; }

    public override void Execute()
    {
        Debug.Log("=>> left MB released");
        model.MouseState = false;

        trayView.ShapeDrop();
    }

}