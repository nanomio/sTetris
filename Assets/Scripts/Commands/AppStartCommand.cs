using strange.extensions.command.impl;
using UnityEngine;

public class AppStartCommand : Command
{

    [Inject]
    public IInput input { get; private set; }

    [Inject]
    public ITrayView trays { get; private set; }

    [Inject]
    public IShapeView shapes { get; private set; }

    public override void Execute()
    {
        Debug.Log("----------------> Initialization start <----------------");

        input.Init();
        shapes.Init();
        trays.Init();

        Debug.Log("----------------> Initialization end <------------------");
    }

}