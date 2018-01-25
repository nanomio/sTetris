using strange.extensions.command.impl;
using UnityEngine;

public class ShapePlaceCommand : Command
{

    [Inject]
    public TraysModel mTrays { get; private set; }

    [Inject]
    public ITrayView TrayView { get; private set; }
    [Inject]
    public IBoardView Board { get; private set; }

    public override void Execute()
    {
        Board.Place();

        Board.CheckLine();

        mTrays.shapesLeft--;
        if (mTrays.shapesLeft == 0)
            TrayView.SpawnAll();
    }

}