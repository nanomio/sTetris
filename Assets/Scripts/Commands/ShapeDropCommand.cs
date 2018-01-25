using strange.extensions.command.impl;
using UnityEngine;

public class ShapeDropCommand : Command
{

    [Inject]
    public IShapeView Shape { get; private set; }

    [Inject]
    public IBoardView Board { get; private set; }

    public override void Execute()
    {
        Shape.Drop();
    }

}