
using System;
using System.Linq;
using System.Runtime.InteropServices;


namespace ATN.WinApi
{
	/// <summary>
	/// Description of mouse.
	/// </summary>
	public static class Mouse
	{
		[DllImport("User32.Dll")]
		public static extern long SetCursorPos(int x, int y);
		
		[DllImport("user32.dll")]
		static extern bool GetCursorPos(out POINT lpPoint);

		[DllImport("User32.Dll")]
		public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);
    
    

		[StructLayout(LayoutKind.Sequential)]
		public struct POINT
		{
			public int x;
			public int y;
		}
		
		[DllImport("user32.dll")]
		static extern void MouseEvent(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

		/// <summary>
		/// Mousebutton arguments
		/// </summary>
		[Flags]
		public enum MouseEventFlags
		{
			WM_LBUTTONDOWN = 0x0201,
			WM_LBUTTONUP = 0x0201,
			MIDDLEDOWN = 0x00000020,
			MIDDLEUP = 0x00000040,
			MOVE = 0x00000001,
			ABSOLUTE = 0x00008000,
			RIGHTDOWN = 0x00000008,
			RIGHTUP = 0x00000010
		}
		
		public static void LeftClick(int x, int y)
		{
			//Cursor.Position = new System.Drawing.Point(x, y);
			MouseEvent((int)(MouseEventFlags.WM_LBUTTONDOWN), 0, 0, 0, 0);
			MouseEvent((int)(MouseEventFlags.WM_LBUTTONUP), 0, 0, 0, 0);
		}
		
		public static void Move(int xDelta, int yDelta)
		{
			MouseEvent((int)MouseEventFlags.MOVE, xDelta, yDelta, 0, 0);
		}
		
		public static POINT GetCursorPosition()
		{
            GetCursorPos(out POINT lpPoint);
            return lpPoint;
		}
	}
}
