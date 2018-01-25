using strange.extensions.command.impl;
using UnityEngine;

public class AppStartCommand : Command
{

    [Inject]
    public IInput Input { get; private set; }

    [Inject]
    public IBoardView Board { get; private set; }

    [Inject]
    public ITrayView Trays { get; private set; }

    [Inject]
    public IShapeView Shapes { get; private set; }

    public override void Execute()
    {
        Debug.Log("----------------> Initialization start <----------------");

        Board.Init();
        Shapes.Init();
        Trays.Init();

        Input.Init();

        Debug.Log("----------------> Initialization end <------------------");
    }

}