using System;

namespace Mania.Launcher.Logic
{
    public class LauncherStateEventArgs : EventArgs
    {
        public LauncherStateEventArgs(LauncherState state)
        {
            State = state;
        }

        public LauncherState State { get; protected set; }
    }
}
