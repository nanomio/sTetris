using System;
using System.Collections;
using UnityEngine;
using strange.extensions.mediation.impl;

public class MouseInputView : IInput
{
    [Inject]
    public IRoutineRunner routineRunner { get; set; }

    [Inject]
    public MouseClickSignal mClick_signal { get; private set; }
    [Inject]
    public MouseReleaseSignal mRelease_signal { get; private set; }


    [PostConstruct]
    public void PostConstruct()
    {
        routineRunner.Execute(update());
    }

    public void Init()
    {
        Debug.Log("Mouse input................................................inited");
    }

    protected IEnumerator update()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
                mClick_signal.Dispatch();

            if (Input.GetMouseButtonUp(0))
                mRelease_signal.Dispatch();

            yield return null;
        }
    }
}