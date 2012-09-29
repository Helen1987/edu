using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PInvoke
{
    class WindowsEnumeration
    {
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hwnd, StringBuilder text, int maxCount);

        delegate bool WindowEnumProc(IntPtr hwnd, int lparam);

        [DllImport("user32.dll")]
        static extern bool EnumWindows(WindowEnumProc enumProc, int lparam);

        static void Main(string[] args)
        {
            WindowEnumProc callback = delegate(IntPtr hwnd, int lparam)
            {
                StringBuilder text = new StringBuilder(200);
                GetWindowText(hwnd, text, text.Capacity);
                if (text.Length != 0)
                    Console.WriteLine(text.ToString());
                return true;
            };
            EnumWindows(callback, 0);
        }
    }
}
