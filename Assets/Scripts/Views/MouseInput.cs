using System;
using System.Collections;
using UnityEngine;
using strange.extensions.mediation.impl;

public class MouseInput : IInput
{
    [Inject]
    public IRoutineRunner routinerunner { get; set; }

    [Inject]
    public MouseClickSignal mc_signal { get; private set; }
    [Inject]
    public MouseReleaseSignal mr_signal { get; private set; }


    [PostConstruct]
    public void PostConstruct()
    {
        routinerunner.Execute(update());
    }

    public void Init()
    {
        Debug.Log("Mouse input inited.");
    }

    protected IEnumerator update()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
                mc_signal.Dispatch();

            if (Input.GetMouseButtonUp(0))
                mr_signal.Dispatch();

            yield return null;
        }
    }
}