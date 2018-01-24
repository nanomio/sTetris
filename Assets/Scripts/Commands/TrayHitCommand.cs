using strange.extensions.command.impl;
using UnityEngine;

public class TrayHitCommand : Command
{
    [Inject]
    public int trayNumber { get; private set; }

    [Inject]
    public ITrayView trayView { get; private set; }

    public override void Execute()
    {
        Debug.Log("Tray " + (trayNumber + 1) + " hited. Start dragging.");

        trayView.ShapeMove(trayNumber);
    }

}