using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WorkingHour
{
    public class KeyLogger
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static Action<Keys> _keyDownAction;
        private static readonly LowLevelKeyboardProc Proc = HookCallback;

        private static IntPtr _hookId = IntPtr.Zero;

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        public static void Start(Action<Keys> keyDownAction)
        {
            _keyDownAction = keyDownAction;
            _hookId = SetHook(Proc);
            //Application.Run();
            //UnhookWindowsHookEx(_hookId);
        }
        public static void Stop()
        {
            UnhookWindowsHookEx(_hookId);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0 || wParam != (IntPtr) WM_KEYDOWN) return CallNextHookEx(_hookId, nCode, wParam, lParam);
            var vkCode = Marshal.ReadInt32(lParam);
            //var keyName = Enum.GetName(typeof(Keys), vkCode);
            _keyDownAction((Keys)vkCode);
            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }
    }
}