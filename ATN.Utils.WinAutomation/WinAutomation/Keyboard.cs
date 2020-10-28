
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics;

using System.Threading;
using System.Collections.ObjectModel;

namespace ATN.WinApi
{
	/// <summary>
	/// Description of keyboard.
	/// </summary>

	public static class Keyboard // SHould not be used, Use windowsinput instead
	{
		/// <summary>
		/// Key actions
		/// </summary>
		public enum KeyboardState
		{
			KeyDown = 0x0100,
			KeyUp = 0x0101,
			SysKeyDown = 0x0104,
			SysKeyUp = 0x0105
		}
		
		/// <summary>
		/// Keys
		/// </summary>
		public struct Key
		{
			//https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
			public const int VK_BACK = 0x08;
			public const int VK_TAB = 0x09;
			public const int VK_CLEAR = 0x0C;
			public const int VK_RETURN = 0x0D;
			public const int VK_SHIFT = 0x10;
			public const int VK_CONTROL = 0x11;
			public const int VK_MENU =0x12;
			public const int VK_PAUSE = 0x13;
			public const int VK_CAPITAL = 0x14;
			public const int VK_ESCAPE = 0x1B;
			public const int VK_SPACE = 0x20;
			public const int VK_PRIOR = 0x21;
			public const int VK_NEXT = 0x22;
			public const int VK_END = 0x23;
			public const int VK_HOME = 0x24;
			public const int VK_LEFT = 0x25;
			public const int VK_UP = 0x26;
			public const int VK_RIGHT = 0x27;
			public const int VK_DOWN = 0x28;
			public const int VK_SELECT = 0x29;
			public const int VK_PRINT = 0x2A;
			public const int VK_EXECUTE = 0x2B;
			public const int VK_SNAPSHOT = 0x2C;
			public const int VK_INSERT = 0x2D;
			public const int VK_DELETE = 0x2E;
			public const int D0 = 0x30;
			public const int D1 = 0x31;
			public const int D2 = 0x32;
			public const int D3 = 0x33;
			public const int D4 = 0x34;
			public const int D5 = 0x35;
			public const int D6 = 0x36;
			public const int D7 = 0x37;
			public const int D8 = 0x38;
			public const int D9 = 0x39;
			public const int A = 0x41;
			public const int B = 0x42;
			public const int C = 0x43;
			public const int D = 0x44;
			public const int E = 0x45;
			public const int F = 0x46;
			public const int G = 0x47;
			public const int H = 0x48;
			public const int I = 0x49;
			public const int J = 0x4A;
			public const int K = 0x4B;
			public const int L = 0x4C;
			public const int M = 0x4D;
			public const int N = 0x4E;
			public const int O = 0x4F;
			public const int P = 0x50;
			public const int Q = 0x51;
			public const int R = 0x52;
			public const int S = 0x53;
			public const int T = 0x54;
			public const int U = 0x55;
			public const int V = 0x56;
			public const int W = 0x57;
			public const int X = 0x58;
			public const int Y = 0x59;
			public const int Z = 0x5A;
			public const int VK_LWIN = 0x5B;
			public const int VK_RWIN = 0x5C;
			public const int VK_APPS = 0x5D;
			public const int VK_NUMPAD0 = 0x60;
			public const int VK_NUMPAD1 = 0x61;
			public const int VK_NUMPAD2 = 0x62;
			public const int VK_NUMPAD3 = 0x63;
			public const int VK_NUMPAD4 = 0x64;
			public const int VK_NUMPAD5 = 0x65;
			public const int VK_NUMPAD6 = 0x66;
			public const int VK_NUMPAD7 = 0x67;
			public const int VK_NUMPAD8 = 0x68;
			public const int VK_NUMPAD9 = 0x69;
			public const int VK_SEPARATOR = 0x6C;
			public const int VK_SUBTRACT = 0x6D;
			public const int VK_DECIMAL = 0x6E;
			public const int VK_DIVIDE = 0x6F;
			public const int VK_F1 = 0x70;
			public const int VK_F2 = 0x71;
			public const int VK_F3 = 0x72;
			public const int VK_F4 = 0x73;
			public const int VK_F5 = 0x74;
			public const int VK_F6 = 0x75;
			public const int VK_F7 = 0x76;
			public const int VK_F8 = 0x77;
			public const int VK_F9 = 0x78;
			public const int VK_F10 = 0x79;
			public const int VK_F11 = 0x7A;
			public const int VK_F12 = 0x7B;
			public const int VK_LSHIFT = 0xA0;
			public const int VK_RSHIFT = 0xA1;
			public const int VK_LCONTROL = 0xA2;
			public const int VK_RCONTROL = 0xA3;
			public const int VK_LMENU = 0xA4;
			public const int VK_RMENU = 0xA5;
			public const int VK_OEM_1 = 0xBA; // ;:
			public const int VK_OEM_PLUS = 0xBB; //For any country/region, the '+' key
			public const int VK_OEM_COMMA = 0xBC;//For any country/region, the ',' key
			public const int VK_OEM_MINUS = 0xBD;//For any country/region, the '-' key
			public const int VK_OEM_PERIOD = 0xBE;//For any country/region, the '.' key
			public const int VK_OEM_2 = 0xBF; //For the US standard keyboard, the '/?' key
			public const int VK_OEM_3 = 0xC0; // For the US standard keyboard, the '~' key
			public const int VK_OEM_CLEAR = 0xFE;
		}
		
		
		public const int WH_KEYBOARD_LL = 13;
		public const int HC_ACTION = 0;



			
		[DllImport("user32.dll")]
		static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);
		
		[DllImport("user32.dll")]
		static extern bool SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);
		
    
		public static void Preskey(IntPtr hWnd, int Key)
		{
			SendMessage(hWnd, (UInt32)KeyboardState.KeyDown, Key, 0);
		}
		
		//Key events occur in the following order:
		//KeyDown
		//KeyPress
		//KeyUp
		//The KeyPress event is not raised by noncharacter keys; however, the noncharacter keys do raise the KeyDown and KeyUp events.
		//Control is a noncharacter key
		

		
		public class GlobalKeyHookThread
		{
			private readonly Thread _thread;
			public  Keyboard.GlobalKeyboardHook _globalKeyboardHook;

            public GlobalKeyHookThread()
			{
				_globalKeyboardHook = new Keyboard.GlobalKeyboardHook();

                _thread = new System.Threading.Thread(NewThread)
                {
                    //set the thread to run in the background
                    IsBackground = true,
                    //name our thread (optional)
                    Name = "GlobalKey"
                };

                _thread.SetApartmentState(ApartmentState.MTA);
				//start our thread
				_thread.Start();
			}
			
				~GlobalKeyHookThread()
			{
				if (_globalKeyboardHook != null)
					_globalKeyboardHook.Dispose();
			}
		
			//
			private void NewThread()
			{
				_globalKeyboardHook.KeyboardPressed += OnKey;
			}
			
			private void OnKey(object sender, ATN.WinApi.Keyboard.GlobalKeyboardHookEventArgs e)
			{
				Debug.WriteLine(e.KeyboardData.VirtualCode);
				
				
				e.Handled = true;
			}
		}
		
	
		public class GlobalKeyboardHookEventArgs : HandledEventArgs
		{
			public Keyboard.KeyboardState KeyboardState { get; private set; }
			public GlobalKeyboardHook.LowLevelKeyboardInputEvent KeyboardData { get; private set; }

			public GlobalKeyboardHookEventArgs(
				GlobalKeyboardHook.LowLevelKeyboardInputEvent keyboardData,
				Keyboard.KeyboardState keyboardState)
			{
				KeyboardData = keyboardData;
				KeyboardState = keyboardState;
			}
		}

		//Based on https://gist.github.com/Stasonix
		public class GlobalKeyboardHook : IDisposable
		{
			public event EventHandler<GlobalKeyboardHookEventArgs> KeyboardPressed;

			public GlobalKeyboardHook()
			{
				_windowsHookHandle = IntPtr.Zero;
				_user32LibraryHandle = IntPtr.Zero;
				_hookProc = LowLevelKeyboardProc; // we must keep alive _hookProc, because GC is not aware about SetWindowsHookEx behaviour.

				_user32LibraryHandle = LoadLibrary("User32");
				if (_user32LibraryHandle == IntPtr.Zero) {
					int errorCode = Marshal.GetLastWin32Error();
					throw new Win32Exception(errorCode, @"Failed to load library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
				}



				_windowsHookHandle = SetWindowsHookEx(Keyboard.WH_KEYBOARD_LL, _hookProc, _user32LibraryHandle, 0);
				if (_windowsHookHandle == IntPtr.Zero) {
					int errorCode = Marshal.GetLastWin32Error();
					throw new Win32Exception(errorCode, @"Failed to adjust keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
				}
			}

			protected virtual void Dispose(bool disposing)
			{
				if (disposing) {
					// because we can unhook only in the same thread, not in garbage collector thread
					if (_windowsHookHandle != IntPtr.Zero) {
						if (!UnhookWindowsHookEx(_windowsHookHandle)) {
							int errorCode = Marshal.GetLastWin32Error();
							throw new Win32Exception(errorCode, @"Failed to remove keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
						}
						_windowsHookHandle = IntPtr.Zero;

						// ReSharper disable once DelegateSubtraction
						_hookProc -= LowLevelKeyboardProc;
					}
				}

				if (_user32LibraryHandle != IntPtr.Zero) {
					if (!FreeLibrary(_user32LibraryHandle)) { // reduces reference to library by 1.
						int errorCode = Marshal.GetLastWin32Error();
						throw new Win32Exception(errorCode, @"Failed to unload library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
					}
					_user32LibraryHandle = IntPtr.Zero;
				}
			}

			~GlobalKeyboardHook()
			{
				Dispose(false);
			}

			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}

			private IntPtr _windowsHookHandle;
			private IntPtr _user32LibraryHandle;
			private HookProc _hookProc;

			delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

			[DllImport("kernel32.dll")]
			private static extern IntPtr LoadLibrary(string lpFileName);

			[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
			private static extern bool FreeLibrary(IntPtr hModule);

			/// <summary>
			/// The SetWindowsHookEx function installs an application-defined hook procedure into a hook chain.
			/// You would install a hook procedure to monitor the system for certain types of events. These events are
			/// associated either with a specific thread or with all threads in the same desktop as the calling thread.
			/// </summary>
			/// <param name="idHook">hook type</param>
			/// <param name="lpfn">hook procedure</param>
			/// <param name="hMod">handle to application instance</param>
			/// <param name="dwThreadId">thread identifier</param>
			/// <returns>If the function succeeds, the return value is the handle to the hook procedure.</returns>
			[DllImport("USER32", SetLastError = true)]
			static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

			/// <summary>
			/// The UnhookWindowsHookEx function removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
			/// </summary>
			/// <param name="hhk">handle to hook procedure</param>
			/// <returns>If the function succeeds, the return value is true.</returns>
			[DllImport("USER32", SetLastError = true)]
			public static extern bool UnhookWindowsHookEx(IntPtr hHook);

			/// <summary>
			/// The CallNextHookEx function passes the hook information to the next hook procedure in the current hook chain.
			/// A hook procedure can call this function either before or after processing the hook information.
			/// </summary>
			/// <param name="hHook">handle to current hook</param>
			/// <param name="code">hook code passed to hook procedure</param>
			/// <param name="wParam">value passed to hook procedure</param>
			/// <param name="lParam">value passed to hook procedure</param>
			/// <returns>If the function succeeds, the return value is true.</returns>
			[DllImport("USER32", SetLastError = true)]
			static extern IntPtr CallNextHookEx(IntPtr hHook, int code, IntPtr wParam, IntPtr lParam);

			[StructLayout(LayoutKind.Sequential)]
			public struct LowLevelKeyboardInputEvent
			{
				/// <summary>
				/// A virtual-key code. The code must be a value in the range 1 to 254.
				/// </summary>
				public int VirtualCode;

				/// <summary>
				/// A hardware scan code for the key. 
				/// </summary>
				public int HardwareScanCode;

				/// <summary>
				/// The extended-key flag, event-injected Flags, context code, and transition-state flag. This member is specified as follows. An application can use the following values to test the keystroke Flags. Testing LLKHF_INJECTED (bit 4) will tell you whether the event was injected. If it was, then testing LLKHF_LOWER_IL_INJECTED (bit 1) will tell you whether or not the event was injected from a process running at lower integrity level.
				/// </summary>
				public int Flags;

				/// <summary>
				/// The time stamp stamp for this message, equivalent to what GetMessageTime would return for this message.
				/// </summary>
				public int TimeStamp;

				/// <summary>
				/// Additional information associated with the message. 
				/// </summary>
				public IntPtr AdditionalInformation;
			}


			public IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
			{
				bool fEatKeyStroke = false;

				var wparamTyped = wParam.ToInt32();
				if (Enum.IsDefined(typeof(Keyboard.KeyboardState), wparamTyped)) {
					object o = Marshal.PtrToStructure(lParam, typeof(LowLevelKeyboardInputEvent));
					var p = (LowLevelKeyboardInputEvent)o;

					var eventArguments = new GlobalKeyboardHookEventArgs(p, (Keyboard.KeyboardState)wparamTyped);

					EventHandler<GlobalKeyboardHookEventArgs> handler = KeyboardPressed;
					if( handler != null)
						handler.Invoke(this, eventArguments);
					//handler?.Invoke(this, eventArguments);

					fEatKeyStroke = eventArguments.Handled;
				}

				return fEatKeyStroke ? (IntPtr)1 : CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
			}
		}
	}
}
