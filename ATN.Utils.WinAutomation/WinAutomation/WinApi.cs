
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;


public struct LASTINPUTINFO
{
    public uint cbSize;
    public uint dwTime;
}

namespace ATN.WinApi
{
    public static class Window
    {
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern int RegisterWindowMessage(string lpString);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static IntPtr FindWindow(string lpWindowName)
        {
            return FindWindow(String.Empty, lpWindowName);
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetFocus(IntPtr hWnd);//HandleRef hWnd);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
            ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumWindowsProc lpEnumCallbackFunction, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, String lParam);

        //[return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr point);

        [DllImport("User32")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern long GetWindowText(IntPtr hwnd, StringBuilder lpString, long cch);

        [DllImport("User32.dll")]
        public static extern IntPtr GetParent(IntPtr hwnd);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern long GetClassName(IntPtr hwnd, StringBuilder lpClassName, long nMaxCount);

        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, UInt32 nCmdShow);

        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;


        public struct Actions
        {
            public const int WM_USER = 0x400;
            public const int WM_COPYDATA = 0x4A;

            /// <summary>
            /// Button click
            /// </summary>
            public const int BM_CLICK = 0x00F5;

            /// <summary>
            /// Set text
            /// </summary>
            public const int WM_SETTEXT = 0x000C;
            public const int CB_SETCURSEL = 0x014E;
            public const int CB_FINDSTRINGEXACT = 0x0158;
            public const int CB_SHOWDROPDOWN = 0x014F;
            public const int CB_FINDSTRING = 0x014C;
        }


        //Used for WM_COPYDATA for string messages
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        public static void SendMessege(IntPtr h)
        {

        }

        public static void MaximizeWindow(IntPtr h)
        {
            if (!h.Equals(IntPtr.Zero))
            {
                ShowWindowAsync(h, SW_SHOWMAXIMIZED);
            }
        }

        public static void MinimizeWindow(IntPtr h)
        {
            if (!h.Equals(IntPtr.Zero))
            {
                ShowWindowAsync(h, SW_SHOWMINIMIZED);
            }
        }

        public static IEnumerable<IntPtr> FindWindows()
        {
            var windows = new List<IntPtr>();

            bool filter(IntPtr hWnd, IntPtr lParam)
            {
                string strTitle = GetCaptionOfWindow(hWnd);

                if (IsWindowVisible(hWnd) && string.IsNullOrEmpty(strTitle) == false)
                {
                    windows.Add(hWnd);
                }
                return true;
            }

            if (!EnumDesktopWindows(IntPtr.Zero, filter, IntPtr.Zero))
            {
                return null;
            }

            return windows;
        }




        public static string GetCaptionOfWindow(IntPtr hwnd)
        {
            string caption = "";
            StringBuilder windowText;
            try
            {
                int max_length = GetWindowTextLength(hwnd);
                windowText = new StringBuilder("", max_length + 5);
                GetWindowText(hwnd, windowText, max_length + 2);

                if (!String.IsNullOrEmpty(windowText.ToString()) && !String.IsNullOrWhiteSpace(windowText.ToString()))
                    caption = windowText.ToString();
            }
            catch (Exception ex)
            {
                caption = ex.Message;
            }
            return caption;
        }

        public static string GetClassNameOfWindow(IntPtr hwnd)
        {
            string className = "";
            StringBuilder classText;
            try
            {
                const int cls_max_length = 1000;
                classText = new StringBuilder("", cls_max_length + 5);
                GetClassName(hwnd, classText, cls_max_length + 2);

                if (!String.IsNullOrEmpty(classText.ToString()) && !String.IsNullOrWhiteSpace(classText.ToString()))
                    className = classText.ToString();
            }
            catch (Exception ex)
            {
                className = ex.Message;
            }

            return className;
        }

        public static IntPtr FindWindowWhere(Func<IntPtr, bool> func, int timeout = 2000)
        {
            const int timer = 100;
            int ticks = timeout / timer;

            for (int i = 0; i < ticks; i++)
            {
                var windows = WinApi.Window.FindWindows();

                var windows_list = windows.Where(x => func(x)).ToList();

                if (windows_list.Count == 1)
                {
                    return windows_list[0];
                }
                System.Threading.Thread.Sleep(timer);
            }
            throw new Exception("No window found");
        }

        public static IntPtr FindWindowFromCaptation(string captation, int timeout = 2000)
        {
            return FindWindowWhere(x => WinApi.Window.GetCaptionOfWindow(x) == captation, timeout);
        }

        public static IntPtr FindWindowFromCaptationRegex(string pattern, int timeout = 2000)
        {
            return FindWindowWhere(x => System.Text.RegularExpressions.Regex.IsMatch(WinApi.Window.GetCaptionOfWindow(x), pattern), timeout);
        }

        public static bool WaitForWindow(IntPtr wh, int timeout = 20000)
        {
            const int timer = 100;
            int ticks = timeout / timer;

            for (int i = 0; i < ticks; i++)
            {
                bool found = false;
                foreach (var window in WinApi.Window.FindWindows())
                {
                    if (window == wh)
                    {
                        found = true;
                    }
                }
                if (found == false)
                {
                    return true;
                }
                System.Threading.Thread.Sleep(timer);
            }
            return false;

        }
    }

    public static class Computer
    {
        [DllImport("User32.dll")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("Kernel32.dll")]
        public static extern uint GetLastError();

        public static long GetLastInputTime()
        {
            var lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            if (GetLastInputInfo(ref lastInPut))
            {
                throw new Exception(GetLastError().ToString());
            }
            return lastInPut.dwTime;
        }

        public static uint GetIdleTime()
        {
            var lastInPut = new LASTINPUTINFO();
            lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            return ((uint)Environment.TickCount - lastInPut.dwTime);
        }
    }






}
