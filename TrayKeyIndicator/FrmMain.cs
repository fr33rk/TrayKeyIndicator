using System;
using System.Windows.Forms;
using TrayKeyIndicatorCore;

namespace TrayKeyIndicator
{
    public partial class FrmMain : Form
    {
        private KeyService mKeyService;
        private NotifyIcon mTrayIcon;

        public FrmMain()
        {
            InitializeComponent();
            mKeyService = new KeyService();
            mKeyService.OnKeyLockStateChanged += (sender, args) => UpdateState(args.IsCapsLock, args.IsNumLock);

            mTrayIcon = new NotifyIcon();
            UpdateState(mKeyService.CapsLockPressed, mKeyService.NumLockPressed);
            mTrayIcon.Visible = true;
            ShowInTaskbar = false;
        }

        private static string BoolToText(bool value)
        {
            return value ? "on" : "off";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateState(mKeyService.CapsLockPressed, mKeyService.NumLockPressed);
        }

        private void UpdateState(bool isCapsLock, bool isNumLock)
        {
            lblCapsLock.Text = $"Caps Lock is {BoolToText(isCapsLock)}";
            lblNumLock.Text = $"Num Lock is {BoolToText(isNumLock)}";

            Icon = isNumLock
                ? Properties.Resources.NumLockOn
                : Properties.Resources.NumLockOff;

            mTrayIcon.Icon = isNumLock
                ? Properties.Resources.NumLockOn
                : Properties.Resources.NumLockOff;
        }

        private void FrmMain_ResizeBegin(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }
    }
}