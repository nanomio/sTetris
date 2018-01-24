using strange.extensions.signal.impl;

public class AppStartSignal : Signal { }

public class MouseClickSignal : Signal { }
public class MouseReleaseSignal : Signal { }

public class TrayHitSignal : Signal<int> { }