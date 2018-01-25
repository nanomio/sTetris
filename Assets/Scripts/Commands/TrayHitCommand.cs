using strange.extensions.command.impl;
using UnityEngine;

public class TrayHitCommand : Command
{
    [Inject]
    public object tray { get; private set; }

    [Inject]
    public IShapeView Shape { get; set; }

    public override void Execute()
    {
        //Debug.Log("Tray " + (trayNumber + 1) + " hited. Start dragging.");

        if (tray != null)
        {
            GameObject tmp = tray as GameObject;

            if (tmp.transform.childCount > 0)
            {
                tmp = tmp.transform.GetChild(0).gameObject;
                Shape.Move(tmp);
            }
        }

    }

}