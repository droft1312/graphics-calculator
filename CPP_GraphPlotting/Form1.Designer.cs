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
            this.plot = new OxyPlot.WindowsForms.PlotView();
            this.graphPictureBox = new System.Windows.Forms.PictureBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.plotButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.derivativeButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.quotientRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.newtonRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.inputTextbox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.xValueTextbox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.lightRadiobutton = new MaterialSkin.Controls.MaterialRadioButton();
            this.darkRadiobutton = new MaterialSkin.Controls.MaterialRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plot
            // 
            this.plot.Location = new System.Drawing.Point(12, 139);
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
            this.graphPictureBox.Location = new System.Drawing.Point(15, 533);
            this.graphPictureBox.Name = "graphPictureBox";
            this.graphPictureBox.Size = new System.Drawing.Size(773, 442);
            this.graphPictureBox.TabIndex = 5;
            this.graphPictureBox.TabStop = false;
            this.graphPictureBox.Resize += new System.EventHandler(this.graphPictureBox_Resize);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(1451, 12);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(71, 19);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "Function:";
            // 
            // plotButton
            // 
            this.plotButton.AutoSize = true;
            this.plotButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.plotButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.plotButton.Depth = 0;
            this.plotButton.Icon = null;
            this.plotButton.Location = new System.Drawing.Point(1719, 44);
            this.plotButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.plotButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.plotButton.Name = "plotButton";
            this.plotButton.Primary = false;
            this.plotButton.Size = new System.Drawing.Size(55, 36);
            this.plotButton.TabIndex = 9;
            this.plotButton.Text = "Plot";
            this.plotButton.UseVisualStyleBackColor = false;
            this.plotButton.Click += new System.EventHandler(this.plotGraph_Click);
            // 
            // derivativeButton
            // 
            this.derivativeButton.AutoSize = true;
            this.derivativeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.derivativeButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.derivativeButton.Depth = 0;
            this.derivativeButton.Icon = null;
            this.derivativeButton.Location = new System.Drawing.Point(1678, 92);
            this.derivativeButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.derivativeButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.derivativeButton.Name = "derivativeButton";
            this.derivativeButton.Primary = false;
            this.derivativeButton.Size = new System.Drawing.Size(97, 36);
            this.derivativeButton.TabIndex = 10;
            this.derivativeButton.Text = "Derivative";
            this.derivativeButton.UseVisualStyleBackColor = false;
            this.derivativeButton.Click += new System.EventHandler(this.derivativeButton_Click);
            // 
            // quotientRadioButton
            // 
            this.quotientRadioButton.AutoSize = true;
            this.quotientRadioButton.Depth = 0;
            this.quotientRadioButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.quotientRadioButton.Location = new System.Drawing.Point(1565, 92);
            this.quotientRadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.quotientRadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.quotientRadioButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.quotientRadioButton.Name = "quotientRadioButton";
            this.quotientRadioButton.Ripple = true;
            this.quotientRadioButton.Size = new System.Drawing.Size(100, 30);
            this.quotientRadioButton.TabIndex = 11;
            this.quotientRadioButton.TabStop = true;
            this.quotientRadioButton.Text = "By Quotient";
            this.quotientRadioButton.UseVisualStyleBackColor = true;
            // 
            // newtonRadioButton
            // 
            this.newtonRadioButton.AutoSize = true;
            this.newtonRadioButton.Depth = 0;
            this.newtonRadioButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.newtonRadioButton.Location = new System.Drawing.Point(1470, 92);
            this.newtonRadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.newtonRadioButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.newtonRadioButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.newtonRadioButton.Name = "newtonRadioButton";
            this.newtonRadioButton.Ripple = true;
            this.newtonRadioButton.Size = new System.Drawing.Size(95, 30);
            this.newtonRadioButton.TabIndex = 12;
            this.newtonRadioButton.TabStop = true;
            this.newtonRadioButton.Text = "By Newton";
            this.newtonRadioButton.UseVisualStyleBackColor = true;
            // 
            // inputTextbox
            // 
            this.inputTextbox.Depth = 0;
            this.inputTextbox.Hint = "";
            this.inputTextbox.Location = new System.Drawing.Point(1528, 12);
            this.inputTextbox.MaxLength = 32767;
            this.inputTextbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.inputTextbox.Name = "inputTextbox";
            this.inputTextbox.PasswordChar = '\0';
            this.inputTextbox.SelectedText = "";
            this.inputTextbox.SelectionLength = 0;
            this.inputTextbox.SelectionStart = 0;
            this.inputTextbox.Size = new System.Drawing.Size(247, 23);
            this.inputTextbox.TabIndex = 13;
            this.inputTextbox.TabStop = false;
            this.inputTextbox.UseSystemPasswordChar = false;
            // 
            // xValueTextbox
            // 
            this.xValueTextbox.Depth = 0;
            this.xValueTextbox.ForeColor = System.Drawing.Color.LimeGreen;
            this.xValueTextbox.Hint = "";
            this.xValueTextbox.Location = new System.Drawing.Point(58, 12);
            this.xValueTextbox.MaxLength = 32767;
            this.xValueTextbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.xValueTextbox.Name = "xValueTextbox";
            this.xValueTextbox.PasswordChar = '\0';
            this.xValueTextbox.SelectedText = "";
            this.xValueTextbox.SelectionLength = 0;
            this.xValueTextbox.SelectionStart = 0;
            this.xValueTextbox.Size = new System.Drawing.Size(75, 23);
            this.xValueTextbox.TabIndex = 14;
            this.xValueTextbox.TabStop = false;
            this.xValueTextbox.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(30, 12);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(22, 19);
            this.materialLabel2.TabIndex = 15;
            this.materialLabel2.Text = "X:";
            // 
            // lightRadiobutton
            // 
            this.lightRadiobutton.AutoSize = true;
            this.lightRadiobutton.Depth = 0;
            this.lightRadiobutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lightRadiobutton.Location = new System.Drawing.Point(3, 29);
            this.lightRadiobutton.Margin = new System.Windows.Forms.Padding(0);
            this.lightRadiobutton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lightRadiobutton.MouseState = MaterialSkin.MouseState.HOVER;
            this.lightRadiobutton.Name = "lightRadiobutton";
            this.lightRadiobutton.Ripple = true;
            this.lightRadiobutton.Size = new System.Drawing.Size(60, 30);
            this.lightRadiobutton.TabIndex = 16;
            this.lightRadiobutton.TabStop = true;
            this.lightRadiobutton.Text = "Light";
            this.lightRadiobutton.UseVisualStyleBackColor = true;
            this.lightRadiobutton.CheckedChanged += new System.EventHandler(this.lightRadiobutton_CheckedChanged);
            // 
            // darkRadiobutton
            // 
            this.darkRadiobutton.AutoSize = true;
            this.darkRadiobutton.Depth = 0;
            this.darkRadiobutton.Font = new System.Drawing.Font("Roboto", 10F);
            this.darkRadiobutton.Location = new System.Drawing.Point(82, 29);
            this.darkRadiobutton.Margin = new System.Windows.Forms.Padding(0);
            this.darkRadiobutton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.darkRadiobutton.MouseState = MaterialSkin.MouseState.HOVER;
            this.darkRadiobutton.Name = "darkRadiobutton";
            this.darkRadiobutton.Ripple = true;
            this.darkRadiobutton.Size = new System.Drawing.Size(57, 30);
            this.darkRadiobutton.TabIndex = 17;
            this.darkRadiobutton.TabStop = true;
            this.darkRadiobutton.Text = "Dark";
            this.darkRadiobutton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lightRadiobutton);
            this.groupBox1.Controls.Add(this.darkRadiobutton);
            this.groupBox1.Location = new System.Drawing.Point(149, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 58);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "App Theme";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1787, 987);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.xValueTextbox);
            this.Controls.Add(this.inputTextbox);
            this.Controls.Add(this.newtonRadioButton);
            this.Controls.Add(this.quotientRadioButton);
            this.Controls.Add(this.derivativeButton);
            this.Controls.Add(this.plotButton);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.graphPictureBox);
            this.Controls.Add(this.plot);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OxyPlot.WindowsForms.PlotView plot;
        private System.Windows.Forms.PictureBox graphPictureBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFlatButton plotButton;
        private MaterialSkin.Controls.MaterialFlatButton derivativeButton;
        private MaterialSkin.Controls.MaterialRadioButton quotientRadioButton;
        private MaterialSkin.Controls.MaterialRadioButton newtonRadioButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField inputTextbox;
        private MaterialSkin.Controls.MaterialSingleLineTextField xValueTextbox;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRadioButton lightRadiobutton;
        private MaterialSkin.Controls.MaterialRadioButton darkRadiobutton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

