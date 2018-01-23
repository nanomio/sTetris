using strange.extensions.command.impl;
using UnityEngine;

public class AppStartCommand : Command
{

    [Inject]
    public IInput input { get; set; }

    public override void Execute()
    {
        Debug.Log("Application started!");

        input.Init();
    }

}