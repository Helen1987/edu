using System;

namespace DelegatesAndEvents.SystemEventsFramework
{
    /// <summary>
    /// Represents one of the system events in the Microsoft.Win32.SystemEvents class.
    /// </summary>
    public enum SystemEventKind
    {
        DisplaySettingsChanged,
        DisplaySettingsChanging,
        InstalledFontsChanged,
        PaletteChanged,
        PowerModeChanged,
        SessionEnded,
        SessionEnding,
        SessionSwitch,
        TimeChanged,
        TimerElapsed,
        UserPreferenceChanged,
        UserPreferenceChanging
    }

    /// <summary>
    /// Indicates that the method decorated by this attribute should be registered to the
    /// specified system event (SystemEventKind).
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public sealed class RegisterSystemEvent : Attribute
    {
        private readonly SystemEventKind _eventKind;

        public SystemEventKind EventKind { get { return _eventKind; } }

        public RegisterSystemEvent(SystemEventKind eventKind)
        {
            _eventKind = eventKind;
        }
    }
}
