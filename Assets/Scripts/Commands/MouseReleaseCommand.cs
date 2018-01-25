using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseReleaseCommand : Command
{

    [Inject]
    public MainModel mMain { get; private set; }

    [Inject]
    public IBoardView Board { get; private set; }
    [Inject]
    public IShapeView Shape { get; private set; }

    public override void Execute()
    {
        Debug.Log("=>> left MB released");
        mMain.MouseState = false;

        Shape.Snap();
        //Board.CheckPlace();
    }

}