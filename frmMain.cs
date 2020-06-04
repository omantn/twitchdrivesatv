using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twitchDrivesATV_Server
{
    public partial class frmMain : Form
    {

        Bot2 twitchBot;

        public frmMain()
        {
            InitializeComponent();
        }

        // This is a very common crossthread contention issue we solve with 
        // the callbacks below:
        // When a vote happens or a vote completes those happen on 
        // callbacks from the twitch API in a background thread created by the twitch api. 
        // Since I am updating UI elements I created call backs on the form itself, 
        // then I have to use an invoke when the callback happens. 
        // The reason for this is the twitch API has
        // background threads for handling inbound messages and events. When
        // those callbacks need to update my UI I have them call THIS series of callbacks.
        // When that happens the callback is executing on the background thread that
        // twitch created. But the problem is you cannot update UI elements from a
        // thread different than the thread they are on. To fix this, invoke
        // forces the context into the thread of the UI elements so it can update them.
        #region C A L L B A C K S

        public void OnTimeUpdate(string timeremaining)
        {
            lblTime.Invoke(new MethodInvoker(delegate 
            {
                lblTime.Text = timeremaining;
                Application.DoEvents();
            }));
        }
        public void OnLeftUpdate(string votes)
        {
            lblLeft.Invoke(new MethodInvoker(delegate
            {
                lblLeft.Text = votes;
                Application.DoEvents();
            }));
        }
        public void OnRightUpdate(string votes)
        {
            lblRight.Invoke(new MethodInvoker(delegate
            {
                lblRight.Text = votes;
                Application.DoEvents();
            }));
        }
        public void OnForewardUpdate(string votes)
        {
            lblForward.Invoke(new MethodInvoker(delegate
            {
                lblForward.Text = votes;
                Application.DoEvents();
            }));
        }
        public void OnBackUpdate(string votes)
        {
            lblBack.Invoke(new MethodInvoker(delegate
            {
                lblBack.Text = votes;
                Application.DoEvents();
            }));
        }
        public void OnListUpdate(string winner)
        {
            lstHistory.Invoke(new MethodInvoker(delegate
            {
                lblLastWinner.Text = winner;
                lstHistory.Items.Add(winner);
                if (lstHistory.Items.Count > 7)
                {
                    lstHistory.Items.RemoveAt(0);
                }
                lstHistory.TopIndex = lstHistory.Items.Count - 1;
                Application.DoEvents();
            }));
        }
        #endregion

        // I could have done this a number of ways, or even in form load.
        // I just chose to kick off the twitch connection via a double click on the form
        private void FrmMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            twitchBot = new Bot2(OnTimeUpdate,OnLeftUpdate,OnRightUpdate,OnForewardUpdate,OnBackUpdate,OnListUpdate);
            
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Bot2.DURATION += 1;
                    break;
                case Keys.Down:
                    Bot2.DURATION -= 1;
                    if (Bot2.DURATION < 1)
                        Bot2.DURATION = 1;
                    break;
                case Keys.PageUp:
                    Bot2.TURN_DURATION += 0.5f;
                    break;
                case Keys.PageDown:
                    Bot2.TURN_DURATION -= 0.5f;
                    if (Bot2.TURN_DURATION < 0.5)
                        Bot2.TURN_DURATION = 0.5f;
                    break;
                case Keys.F:
                    Bot2.SendVehicleCommand("forward");
                    break;
                case Keys.B:
                    Bot2.SendVehicleCommand("backward");
                    break;
                case Keys.L:
                    Bot2.SendVehicleCommand("left");
                    break;
                case Keys.R:
                    Bot2.SendVehicleCommand("right");
                    break;
            }
            this.Text = "Duration = " + Bot2.DURATION.ToString() + ", Turn Duration = " + Bot2.TURN_DURATION.ToString();
        }
    }
}
