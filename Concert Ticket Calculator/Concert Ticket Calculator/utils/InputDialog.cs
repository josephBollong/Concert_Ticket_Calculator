using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concert_Ticket_Calculator.utils
{
    public partial class InputDialog : Form
    {

        GUI gui;
        Engine engine;
        public InputDialog()
        {
            InitializeComponent();
            msgIcon.Image = SystemIcons.Question.ToBitmap();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            gui.clearRows();
            //engine.clearSeats();
            gui.txtOutput.Clear();
            gui.changeRows();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            gui.clearRows();
            //engine.clearSeats();
            gui.txtOutput.Clear();
            this.Close();
        }
    }
}
