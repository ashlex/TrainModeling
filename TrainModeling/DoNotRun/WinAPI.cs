using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DoNotRun
{
	public class WinAPI
	{

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr PostMessage(IntPtr hwnd, uint Msg, int wParam, int lParam);
        [DllImport("user32", EntryPoint = "SetWindowsHookExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int SetWindowsHookEx(int idHook, LowLevelKeyboardProcDelegate lpfn, int hMod, int dwThreadId);
		public delegate int LowLevelKeyboardProcDelegate(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);
		[DllImport("user32", EntryPoint = "CallNextHookEx", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern int CallNextHookEx(int hHook, int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam);

		[DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern IntPtr LoadLibrary(string lpFileName);
		public const int WH_KEYBOARD_LL = 13;
		public static int intLLKey;

		public int LowLevelKeyboardProc(int nCode, int wParam, ref KBDLLHOOKSTRUCT lParam)
		{
			bool blnEat = false;
//			Console.WriteLine("w:");
//			Console.WriteLine("w:"+wParam+"; l:"+lParam.vkCode+" "+lParam.flags);
			switch (wParam)
			{
				case 256:
				case 257:
				case 260:
				case 261:
					//Alt+Tab, Alt+Esc, Ctrl+Esc, Windows Key,
					blnEat = ((lParam.vkCode == 9) && (lParam.flags == 32)) | ((lParam.vkCode == 27) && (lParam.flags == 32)) | ((lParam.vkCode == 27) && (lParam.flags == 0)) | ((lParam.vkCode == 91) && (lParam.flags == 1)) | ((lParam.vkCode == 92) && (lParam.flags == 1)) | ((lParam.vkCode == 73) && (lParam.flags == 0));
					break;
			}

			if (blnEat == true)
			{
				return 1;
			}
//			else
//			{
//				return CallNextHookEx(0, nCode, wParam, ref lParam);
//			}
			return 1;
		}

		public void LockKB()
		{

			var inst = LoadLibrary("user32.dll").ToInt32();
			intLLKey = SetWindowsHookEx(WH_KEYBOARD_LL, LowLevelKeyboardProc, inst, 0);
		}
	}

	public enum GetWindowCmd : uint
	{
		GW_HWNDFIRST = 0,
		GW_HWNDLAST = 1,
		GW_HWNDNEXT = 2,
		GW_HWNDPREV = 3,
		GW_OWNER = 4,
		GW_CHILD = 5,
		GW_ENABLEDPOPUP = 6,
		WM_QUIT = 0x0012,
        WM_GETTEXT = 0x000D
	}
	public struct KBDLLHOOKSTRUCT
	{
		public int vkCode;
		public int scanCode;
		public int flags;
		public int time;
		public int dwExtraInfo;
	}

}