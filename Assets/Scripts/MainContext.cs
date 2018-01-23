﻿using System;
using strange.extensions.command.impl;
using UnityEngine;

public class MainContext : SignalContext
{
    public MainContext(MonoBehaviour view) : base(view)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();

        injectionBinder.Bind<IRoutineRunner>().To<RoutineRunner>().ToSingleton();
        injectionBinder.Bind<IInput>().To<MouseInput>().ToSingleton();
        injectionBinder.Bind<ITrayView>().To<Tray3DView>();

        injectionBinder.Bind<MainModel>().ToSingleton();
        injectionBinder.Bind<ShapesModel>().ToSingleton();

        commandBinder.Bind<AppStartSignal>().To<AppStartCommand>().Once();
        commandBinder.Bind<MouseClickSignal>().To<MouseClickCommand>();
        commandBinder.Bind<MouseReleaseSignal>().To<MouseReleaseCommand>();

    }
}