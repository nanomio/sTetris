using strange.extensions.signal.impl;
using UnityEngine;

public class AppStartSignal : Signal { }

public class MouseClickSignal : Signal { }
public class MouseReleaseSignal : Signal { }

public class TrayHitSignal : Signal<object> { }
public class ShapeDropSignal : Signal { }
public class ShapePlaceSignal : Signal { }