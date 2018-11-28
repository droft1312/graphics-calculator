namespace CPP_GraphPlotting
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.inputTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plotGraph = new System.Windows.Forms.Button();
            this.plot = new OxyPlot.WindowsForms.PlotView();
            this.graphPictureBox = new System.Windows.Forms.PictureBox();
            this.findDerivativeButton = new System.Windows.Forms.Button();
            this.trueDerivativeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // inputTextbox
            // 
            this.inputTextbox.Location = new System.Drawing.Point(79, 15);
            this.inputTextbox.Name = "inputTextbox";
            this.inputTextbox.Size = new System.Drawing.Size(245, 20);
            this.inputTextbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Function:";
            // 
            // plotGraph
            // 
            this.plotGraph.Location = new System.Drawing.Point(330, 13);
            this.plotGraph.Name = "plotGraph";
            this.plotGraph.Size = new System.Drawing.Size(75, 23);
            this.plotGraph.TabIndex = 2;
            this.plotGraph.Text = "Plot";
            this.plotGraph.UseVisualStyleBackColor = true;
            this.plotGraph.Click += new System.EventHandler(this.plotGraph_Click);
            // 
            // plot
            // 
            this.plot.Location = new System.Drawing.Point(12, 50);
            this.plot.Name = "plot";
            this.plot.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot.Size = new System.Drawing.Size(776, 388);
            this.plot.TabIndex = 3;
            this.plot.Text = "plotView1";
            this.plot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // graphPictureBox
            // 
            this.graphPictureBox.Location = new System.Drawing.Point(15, 444);
            this.graphPictureBox.Name = "graphPictureBox";
            this.graphPictureBox.Size = new System.Drawing.Size(773, 531);
            this.graphPictureBox.TabIndex = 5;
            this.graphPictureBox.TabStop = false;
            // 
            // findDerivativeButton
            // 
            this.findDerivativeButton.Location = new System.Drawing.Point(411, 13);
            this.findDerivativeButton.Name = "findDerivativeButton";
            this.findDerivativeButton.Size = new System.Drawing.Size(112, 23);
            this.findDerivativeButton.TabIndex = 6;
            this.findDerivativeButton.Text = "Derivative Quotient";
            this.findDerivativeButton.UseVisualStyleBackColor = true;
            this.findDerivativeButton.Click += new System.EventHandler(this.findDerivativeButton_Click);
            // 
            // trueDerivativeButton
            // 
            this.trueDerivativeButton.Location = new System.Drawing.Point(529, 13);
            this.trueDerivativeButton.Name = "trueDerivativeButton";
            this.trueDerivativeButton.Size = new System.Drawing.Size(75, 23);
            this.trueDerivativeButton.TabIndex = 7;
            this.trueDerivativeButton.Text = "Derivative";
            this.trueDerivativeButton.UseVisualStyleBackColor = true;
            this.trueDerivativeButton.Click += new System.EventHandler(this.trueDerivativeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 987);
            this.Controls.Add(this.trueDerivativeButton);
            this.Controls.Add(this.findDerivativeButton);
            this.Controls.Add(this.graphPictureBox);
            this.Controls.Add(this.plot);
            this.Controls.Add(this.plotGraph);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputTextbox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button plotGraph;
        private OxyPlot.WindowsForms.PlotView plot;
        private System.Windows.Forms.PictureBox graphPictureBox;
        private System.Windows.Forms.Button findDerivativeButton;
        private System.Windows.Forms.Button trueDerivativeButton;
    }
}

