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

        bool plotGraph_called = false;

        public Form1 () {
            InitializeComponent ();
            plotter = new Plotter ();

            //this.FormBorderStyle = FormBorderStyle.None;
            // fill the screen
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void plotGraph_Click (object sender, EventArgs e) {
            string input = inputTextbox.Text.Replace(" ", string.Empty);

            List<DataPoint> points = new List<DataPoint>();
            FunctionSeries series = new FunctionSeries ();

            try {
                plotter.ProcessString (input);

                for (int i = -100; i < 100; i++) {
                    points.Add(new DataPoint (i, plotter.ProcessTree (i, plotter.Root)));
                }

                series.Points.AddRange (points);
                PlotModel myModel = new PlotModel () { Title = "Plot" };
                myModel.Series.Add (series);
                plot.Model = myModel;

                plotter.GetGraphImage (graphPictureBox, plotter.Root);

                plotGraph_called = true;

            } catch (Exception ex) {
                MessageBox.Show (ex.Message);
            }
        }

        private void findDerivativeButton_Click (object sender, EventArgs e) {
            if (plotGraph_called) {

                List<DataPoint> points = new List<DataPoint> ();
                FunctionSeries series = new FunctionSeries ();

                try {

                    for (int i = -100; i < 100; i++) {
                        points.Add (new DataPoint (i, plotter.ProcessDerivative_Quotient (i, plotter.Root)));
                    }

                    series.Points.AddRange (points);
                    PlotModel myModel = new PlotModel () { Title = "Plot (derivative)" };
                    myModel.Series.Add (series);
                    plot.Model = myModel;

                    plotter.GetGraphImage (graphPictureBox, plotter.Root);

                    plotGraph_called = true;

                } catch (Exception ex) {
                    MessageBox.Show (ex.Message);
                }


            } else {
                MessageBox.Show ("Please input and plot function first");
            }
        }

        private void trueDerivativeButton_Click (object sender, EventArgs e) {
            plotter.CreateDerivativeTree ();
            plotter.GetGraphImage (graphPictureBox, plotter.DerivativeRoot);

            List<DataPoint> points = new List<DataPoint> ();
            FunctionSeries series = new FunctionSeries ();

            try {

                for (int i = -100; i < 100; i++) {
                    points.Add (new DataPoint (i, plotter.ProcessTree(i, plotter.DerivativeRoot)));
                }

                series.Points.AddRange (points);
                PlotModel myModel = new PlotModel () { Title = "Plot (derivative)" };
                myModel.Series.Add (series);
                plot.Model = myModel;

                plotGraph_called = true;

            } catch (Exception ex) {
                MessageBox.Show (ex.Message);
            }
        }

        private void derivativeButton_Click (object sender, EventArgs e) {
            if (quotientRadioButton.Checked) {
                findDerivativeButton_Click (sender, e);
            } else if (newtonRadioButton.Checked) {
                trueDerivativeButton_Click (sender, e);
            } else {
                MessageBox.Show ("Please choose the method!", "Error");
            }
        }

        private void graphPictureBox_Resize (object sender, EventArgs e) {
            MessageBox.Show ("");
        }
    }
}
