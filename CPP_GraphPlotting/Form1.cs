using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OxyPlot;
using OxyPlot.Series;

namespace CPP_GraphPlotting
{
    public partial class Form1 : Form
    {
        Plotter plotter;

        public Form1 () {
            InitializeComponent ();
            plotter = new Plotter ();
        }

        private void plotGraph_Click (object sender, EventArgs e) {
            string input = inputTextbox.Text.Replace(" ", string.Empty);

            List<DataPoint> points = new List<DataPoint>();
            FunctionSeries series = new FunctionSeries ();

            try {
                plotter.ProcessString (input);

                for (int i = -100; i < 100; i++) {
                    points.Add(new DataPoint (i, plotter.ProcessTree (i)));
                }

                series.Points.AddRange (points);
                PlotModel myModel = new PlotModel () { Title = "Plot" };
                myModel.Series.Add (series);
                plot.Model = myModel;

                plotter.GetGraphImage (graphPictureBox);

            } catch (Exception ex) {
                MessageBox.Show (ex.Message);
            }
        }

        private void button1_Click (object sender, EventArgs e) {
        }
    }
}
