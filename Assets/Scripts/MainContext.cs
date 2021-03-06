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
        injectionBinder.Bind<IInput>().To<MouseInputView>().ToSingleton();

        injectionBinder.Bind<IBoardView>().To<BoardView>();
        injectionBinder.Bind<IShapeView>().To<ShapeView>();
        injectionBinder.Bind<ITrayView>().To<Tray3DView>();

        injectionBinder.Bind<MainModel>().ToSingleton();
        injectionBinder.Bind<BoardModel>().ToSingleton();
        injectionBinder.Bind<BasicShapesModel>().ToSingleton();
        injectionBinder.Bind<GameShapeModel>().ToSingleton();
        injectionBinder.Bind<TraysModel>().ToSingleton();

        commandBinder.Bind<AppStartSignal>().To<AppStartCommand>().Once();
        commandBinder.Bind<MouseClickSignal>().To<MouseClickCommand>();
        commandBinder.Bind<MouseReleaseSignal>().To<MouseReleaseCommand>();
        commandBinder.Bind<TrayHitSignal>().To<TrayHitCommand>();
        commandBinder.Bind<ShapeDropSignal>().To<ShapeDropCommand>();
        commandBinder.Bind<ShapePlaceSignal>().To<ShapePlaceCommand>();

    }
}