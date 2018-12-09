﻿using System;
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

using MathNet;
using MathNet.Numerics;

namespace CPP_GraphPlotting
{
    public partial class Form1 : Form
    {
        Plotter plotter;

        bool plotGraph_called = false;
        bool lightThemeOn = true;

        public Form1 () {
            InitializeComponent ();
            plotter = new Plotter ();

            //this.FormBorderStyle = FormBorderStyle.None;
            // fill the screen
            this.Bounds = Screen.PrimaryScreen.Bounds;
            //this.BackColor = Color.FromArgb (54, 57, 63);
        }

        private void plotGraph_Click (object sender, EventArgs e) {
            string input = inputTextbox.Text.Replace(" ", string.Empty);

            List<DataPoint> points = new List<DataPoint>();
            FunctionSeries series = new FunctionSeries ();

            try {
                plotter.ProcessString (input);

                var boundaries = Boundaries (xValueTextbox.Text);

                for (int i = boundaries[0]; i < boundaries[1]; i++) {
                    points.Add(new DataPoint (i, plotter.ProcessTree (i, plotter.Root)));
                }

                series.Points.AddRange (points);
                PlotModel myModel = new PlotModel () { Title = "Plot" };
                myModel.Series.Add (series);
                plot.Model = myModel;

                plotter.GetGraphImage (graphPictureBox, plotter.Root);

                plotGraph_called = true;

                infixFunctionLabel.Text = "Your function: " + plotter.PrefixToInfix (input);

            } catch (Exception ex) {
                MessageBox.Show (ex.Message);
            }
        }

        private void findDerivativeButton_Click (object sender, EventArgs e) {
            if (plotGraph_called) {

                List<DataPoint> points = new List<DataPoint> ();
                FunctionSeries series = new FunctionSeries ();

                try {

                    var boundaries = Boundaries (xValueTextbox.Text);

                    for (int i = boundaries[0]; i < boundaries[1]; i++) {
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

                var boundaries = Boundaries (xValueTextbox.Text);

                for (int i = boundaries[0]; i < boundaries[1]; i++) {
                    points.Add (new DataPoint (i, plotter.ProcessTree (i, plotter.DerivativeRoot)));
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
            } else if (!quotientRadioButton.Checked && !newtonRadioButton.Checked) {
                MessageBox.Show ("Please choose the method!", "Error");
            }
        }

        private void lightRadiobutton_CheckedChanged (object sender, EventArgs e) {
            if (lightRadiobutton.Checked) {
                lightThemeOn = true;
                PutTheme ();
            } else {
                lightThemeOn = false;
                PutTheme ();
            }
        }

        private int[] Boundaries (string input) {

            if (input == string.Empty) {
                int[] arr = new int[2];
                arr[0] = -100;
                arr[1] = 100;
                return arr;
            }

            string acceptables = ";,-";
            char c = '0';

            foreach (char acceptable in acceptables) {
                if (input.Contains(acceptable)) {
                    c = acceptable;
                    break;
                }
            }

            if (c == '0') throw new Exception ("Please correct your string");

            string[] split = input.Split (c);
            List<int> boundaries = new List<int> ();
            for (int i = 0; i < split.Length; i++) {
                boundaries.Add (int.Parse (split[i]));
            }

            if (boundaries.Count != 2) throw new Exception ("Please correct your string");

            return boundaries.ToArray ();
        }
        
        private void integrateButton_Click (object sender, EventArgs e) {
            string input = inputTextbox.Text.Replace (" ", string.Empty);
            plotter.ProcessString (input);

            try {
                var model = new PlotModel { Title = "AreaSeries" };

                var integralBoundaries = Boundaries (integralInput.Text);
                var funcBoundaries = Boundaries (xValueTextbox.Text);

                var area = new AreaSeries { Title = "Area = " + plotter.ProcessIntegral(integralBoundaries[0], integralBoundaries[1]) };
                List<DataPoint> areaPoints = new List<DataPoint> ();
                var function = new FunctionSeries { Title = "function" };
                List<DataPoint> funcPoints = new List<DataPoint> ();


                // function itself
                for (int i = funcBoundaries[0]; i < funcBoundaries[1]; i++) {
                    funcPoints.Add (new DataPoint (i, plotter.ProcessTree (i, plotter.Root)));
                    if (i >= integralBoundaries[0] && i <= integralBoundaries[1]) {
                        areaPoints.Add (new DataPoint (i, plotter.ProcessTree (i, plotter.Root)));
                        area.Points2.Add (new DataPoint (i, 0));
                    }
                }

                area.Points.AddRange (areaPoints);
                function.Points.AddRange (funcPoints);

                area.Color2 = OxyColors.Transparent;

                model.Series.Add (area);
                model.Series.Add (function);

                plot.Model = model;
            } catch (Exception ex) {
                MessageBox.Show (ex.Message);
            }
        }


        private void PutTheme() {
            if (lightThemeOn) {
                this.BackColor = Color.White;
            } else {
                this.BackColor = Color.FromArgb (54, 57, 63);
            }
        }

        private void AssignDefaultBoundaries(ref int[] boundaries) {
            int[] arr = new int[2];
            arr[0] = -100;
            arr[1] = 100;
            boundaries = arr;
        }
    }
}
