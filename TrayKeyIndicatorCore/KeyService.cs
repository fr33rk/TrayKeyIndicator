using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TrayKeyIndicatorCore
{
    public class KeyService : IDisposable
    {
        public void Dispose()
        {
            UnhookWindowsHookEx(mHookId);
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private readonly LowLevelKeyboardProc mProc;
        private static IntPtr mHookId = IntPtr.Zero;

        public bool CapsLockPressed => Control.IsKeyLocked(Keys.CapsLock);
        public bool NumLockPressed => Control.IsKeyLocked(Keys.NumLock);

        public KeyService()
        {
            mProc = HookCallback;
            mHookId = SetHook(mProc);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)

        {
            using (var curProcess = Process.GetCurrentProcess())
            {
                using (var curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                        GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }

        private IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                var vkCode = Marshal.ReadInt32(lParam);

                var key = (Keys) vkCode;

                if (key == Keys.Capital ||  key == Keys.CapsLock)
                {
                    OnKeyLockStateChanged?.Invoke(this, new KeyLockChangedEventArgs(!CapsLockPressed, NumLockPressed));
                }
                else if (key == Keys.NumLock)
                {
                    OnKeyLockStateChanged?.Invoke(this, new KeyLockChangedEventArgs(CapsLockPressed, !NumLockPressed));
                }
          
            }

            return CallNextHookEx(mHookId, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        public class KeyLockChangedEventArgs : EventArgs
        {
            public KeyLockChangedEventArgs(bool isCapsLock, bool isNumLock)
            {
                IsCapsLock = isCapsLock;
                IsNumLock = isNumLock;
            }

            public bool IsCapsLock { get; }
            public bool IsNumLock { get; }
        }

        public EventHandler<KeyLockChangedEventArgs> OnKeyLockStateChanged;
    }
}