using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrayKeyIndicatorCore;

namespace TrayNumLockIndicator
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            mKeyService = new KeyService();
            mKeyService.OnKeyLockStateChanged += OnKeyLockStateChanged;

            mNotifyIcon = new NotifyIcon();
            UpdateIcon(mKeyService.NumLockPressed);
            mNotifyIcon.ContextMenuStrip = contextMenuStrip1;
            mNotifyIcon.Visible = true;

            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void OnKeyLockStateChanged(object sender, KeyService.KeyLockChangedEventArgs keyLockChangedEventArgs)
        {
           UpdateIcon(keyLockChangedEventArgs.IsNumLock);
        }

        private NotifyIcon mNotifyIcon;
        private KeyService mKeyService;

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
