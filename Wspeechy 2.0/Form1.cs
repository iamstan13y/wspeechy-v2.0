using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Wspeechy_2._0.Properties;
using Speak;
using System.IO;
using Regedit;

namespace Wspeechy_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string username;
        NewReg reg = new NewReg();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Settings.Default.Username = "";
            //Settings.Default.Save();
            if (!(Settings.Default.Username == ""))
            {
                bunifuCards1.Visible = false;
                string mytext = "";
                SpeakLib speak = new SpeakLib();
                DateTime time = DateTime.Now;
                username = Settings.Default.Username;
                int timeCnt = int.Parse(time.Hour.ToString());
                

                if (timeCnt < 12)
                {
                    mytext = "Good Morning " + username + "Hope You Had A Good Night!, How Are You Doing This Morning?";
                }
                else if (timeCnt >= 12 && timeCnt < 18)
                {
                    mytext = "Afternoon " + username + "How Is Your Day Going So Far?, Hope You Are Enjoying!";
                }
                else if (timeCnt >= 18 && timeCnt < 24)
                {
                    mytext = "Evening " + username + "How Was Your Day?, Hope You Enjoyed!, Have A Good Night In Advance!";
                }

                speak.Speak(mytext);
                Application.Exit();

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("Please Enter a Valid Username!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                username = txtUser.Text;
                Settings.Default.Username = username;
                Settings.Default.Save();
                reg.Save(Application.ProductName, Application.ExecutablePath);
                MessageBox.Show("Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WSPEECHY 2.0 \n\nCopyright © 2019. All Rights Reserved \n\n Product of Stanton-Technologies", "About",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tmrMsg_Tick(object sender, EventArgs e)
        {
            if (lblMsg.Visible == true)
            {
                lblMsg.Visible = false;
            } else
            {
                lblMsg.Visible = true;
            }

        }

    }
}
