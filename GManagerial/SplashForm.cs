using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace GManagerial
{
    public partial class Logo : Form
    {
        public Logo()
        {
            InitializeComponent();
        }

        private void Logo_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
            timer.Stop();

            Form currentForm = Application.OpenForms[0];
            currentForm.Close();

            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
    }
}
