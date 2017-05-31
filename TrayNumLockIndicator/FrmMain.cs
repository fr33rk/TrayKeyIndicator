using System;
using System.ComponentModel;
using System.Windows.Forms;
using TrayKeyIndicatorCore;

namespace TrayNumLockIndicator
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            var keyService = new KeyService();
            keyService.OnKeyLockStateChanged += OnKeyLockStateChanged;

            mNotifyIcon = new NotifyIcon();
            UpdateIcon(keyService.NumLockPressed);
            mNotifyIcon.ContextMenuStrip = contextMenuStrip1;
            mNotifyIcon.Visible = true;

            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;

            // Trick to hide the application from the task list.
            var invisibleParent = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                ShowInTaskbar = false
            };

            Owner = invisibleParent;
        }

        private void OnKeyLockStateChanged(object sender, KeyService.KeyLockChangedEventArgs keyLockChangedEventArgs)
        {
            UpdateIcon(keyLockChangedEventArgs.IsNumLock);
        }

        private readonly NotifyIcon mNotifyIcon;

        private void UpdateIcon(bool isEnabled)
        {
            mNotifyIcon.Icon = isEnabled
                ? Properties.Resources.NumLockOn
                : Properties.Resources.NumLockOff;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mNotifyIcon.Visible = false;
            Close();
        }
    }
}