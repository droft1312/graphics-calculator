using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPP_GraphPlotting
{
    public partial class Form1 : Form
    {
        Plotter plotter;

        public Form1 ()
        {
            InitializeComponent ();
            plotter = new Plotter ();
        }

        private void plotGraph_Click (object sender, EventArgs e) {
            string input = inputTextbox.Text;

            try {

            } catch (Exception ex) {
                MessageBox.Show (ex.Message);
            }
        }
    }
}
