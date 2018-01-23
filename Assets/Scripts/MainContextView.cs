using strange.extensions.context.impl;
using strange.extensions.injector.api;
using strange.extensions.signal.impl;
using UnityEngine;

public class MainContextView : ContextView
{
    private void Start()
    {
        var context = new MainContext(this);

        context.Start();
    }
}
