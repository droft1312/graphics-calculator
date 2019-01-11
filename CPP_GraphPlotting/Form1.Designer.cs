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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.plotButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.derivativeButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.quotientRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.newtonRadioButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.inputTextbox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.xValueTextbox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.infixFunctionLabel = new MaterialSkin.Controls.MaterialLabel();
            this.integralInput = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.integrateButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.functionPictureBox = new System.Windows.Forms.PictureBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.derivativePictureBox = new System.Windows.Forms.PictureBox();
            this.integralPictureBox = new System.Windows.Forms.PictureBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.panelPictureBox = new System.Windows.Forms.Panel();
            this.graphPictureBox = new System.Windows.Forms.PictureBox();
            this.calculateMcLaurinSeriesButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.mcLaurienOrderTextBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.polynomialButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.calculateMcLaurienByLimitButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.polynomialPointsListView = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.functionPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.derivativePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integralPictureBox)).BeginInit();
            this.panelPictureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
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
            this.derivativeButton.Location = new System.Drawing.Point(1677, 130);
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
            this.quotientRadioButton.Location = new System.Drawing.Point(1564, 130);
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
            this.newtonRadioButton.Location = new System.Drawing.Point(1469, 130);
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
            this.inputTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTextbox_KeyDown);
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
            this.xValueTextbox.Text = "-100;100";
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
            // infixFunctionLabel
            // 
            this.infixFunctionLabel.AutoSize = true;
            this.infixFunctionLabel.Depth = 0;
            this.infixFunctionLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.infixFunctionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.infixFunctionLabel.Location = new System.Drawing.Point(367, 16);
            this.infixFunctionLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.infixFunctionLabel.Name = "infixFunctionLabel";
            this.infixFunctionLabel.Size = new System.Drawing.Size(103, 19);
            this.infixFunctionLabel.TabIndex = 19;
            this.infixFunctionLabel.Text = "Your function:";
            // 
            // integralInput
            // 
            this.integralInput.Depth = 0;
            this.integralInput.Hint = "";
            this.integralInput.Location = new System.Drawing.Point(1127, 140);
            this.integralInput.MaxLength = 32767;
            this.integralInput.MouseState = MaterialSkin.MouseState.HOVER;
            this.integralInput.Name = "integralInput";
            this.integralInput.PasswordChar = '\0';
            this.integralInput.SelectedText = "";
            this.integralInput.SelectionLength = 0;
            this.integralInput.SelectionStart = 0;
            this.integralInput.Size = new System.Drawing.Size(195, 23);
            this.integralInput.TabIndex = 20;
            this.integralInput.TabStop = false;
            this.integralInput.UseSystemPasswordChar = false;
            this.integralInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.integralInput_KeyDown);
            // 
            // integrateButton
            // 
            this.integrateButton.AutoSize = true;
            this.integrateButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.integrateButton.Depth = 0;
            this.integrateButton.Icon = null;
            this.integrateButton.Location = new System.Drawing.Point(1335, 127);
            this.integrateButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.integrateButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.integrateButton.Name = "integrateButton";
            this.integrateButton.Primary = false;
            this.integrateButton.Size = new System.Drawing.Size(94, 36);
            this.integrateButton.TabIndex = 21;
            this.integrateButton.Text = "Integrate";
            this.integrateButton.UseVisualStyleBackColor = true;
            this.integrateButton.Click += new System.EventHandler(this.integrateButton_Click);
            // 
            // functionPictureBox
            // 
            this.functionPictureBox.Location = new System.Drawing.Point(476, 4);
            this.functionPictureBox.Name = "functionPictureBox";
            this.functionPictureBox.Size = new System.Drawing.Size(185, 60);
            this.functionPictureBox.TabIndex = 22;
            this.functionPictureBox.TabStop = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(818, 923);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(79, 19);
            this.materialLabel3.TabIndex = 23;
            this.materialLabel3.Text = "Derivative:";
            // 
            // derivativePictureBox
            // 
            this.derivativePictureBox.Location = new System.Drawing.Point(903, 886);
            this.derivativePictureBox.Name = "derivativePictureBox";
            this.derivativePictureBox.Size = new System.Drawing.Size(231, 89);
            this.derivativePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.derivativePictureBox.TabIndex = 24;
            this.derivativePictureBox.TabStop = false;
            // 
            // integralPictureBox
            // 
            this.integralPictureBox.Location = new System.Drawing.Point(1289, 886);
            this.integralPictureBox.Name = "integralPictureBox";
            this.integralPictureBox.Size = new System.Drawing.Size(212, 89);
            this.integralPictureBox.TabIndex = 25;
            this.integralPictureBox.TabStop = false;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(1220, 923);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(63, 19);
            this.materialLabel4.TabIndex = 26;
            this.materialLabel4.Text = "Integral:";
            // 
            // panelPictureBox
            // 
            this.panelPictureBox.AutoScroll = true;
            this.panelPictureBox.Controls.Add(this.graphPictureBox);
            this.panelPictureBox.Location = new System.Drawing.Point(12, 547);
            this.panelPictureBox.Name = "panelPictureBox";
            this.panelPictureBox.Size = new System.Drawing.Size(776, 428);
            this.panelPictureBox.TabIndex = 27;
            // 
            // graphPictureBox
            // 
            this.graphPictureBox.Location = new System.Drawing.Point(13, 15);
            this.graphPictureBox.Name = "graphPictureBox";
            this.graphPictureBox.Size = new System.Drawing.Size(749, 400);
            this.graphPictureBox.TabIndex = 0;
            this.graphPictureBox.TabStop = false;
            // 
            // calculateMcLaurinSeriesButton
            // 
            this.calculateMcLaurinSeriesButton.AutoSize = true;
            this.calculateMcLaurinSeriesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.calculateMcLaurinSeriesButton.Depth = 0;
            this.calculateMcLaurinSeriesButton.Icon = null;
            this.calculateMcLaurinSeriesButton.Location = new System.Drawing.Point(1533, 178);
            this.calculateMcLaurinSeriesButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.calculateMcLaurinSeriesButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.calculateMcLaurinSeriesButton.Name = "calculateMcLaurinSeriesButton";
            this.calculateMcLaurinSeriesButton.Primary = false;
            this.calculateMcLaurinSeriesButton.Size = new System.Drawing.Size(97, 36);
            this.calculateMcLaurinSeriesButton.TabIndex = 28;
            this.calculateMcLaurinSeriesButton.Text = "McLaurien";
            this.calculateMcLaurinSeriesButton.UseVisualStyleBackColor = true;
            this.calculateMcLaurinSeriesButton.Click += new System.EventHandler(this.calculateMcLaurinSeriesButton_Click);
            // 
            // mcLaurienOrderTextBox
            // 
            this.mcLaurienOrderTextBox.Depth = 0;
            this.mcLaurienOrderTextBox.Hint = "";
            this.mcLaurienOrderTextBox.Location = new System.Drawing.Point(1445, 191);
            this.mcLaurienOrderTextBox.MaxLength = 32767;
            this.mcLaurienOrderTextBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.mcLaurienOrderTextBox.Name = "mcLaurienOrderTextBox";
            this.mcLaurienOrderTextBox.PasswordChar = '\0';
            this.mcLaurienOrderTextBox.SelectedText = "";
            this.mcLaurienOrderTextBox.SelectionLength = 0;
            this.mcLaurienOrderTextBox.SelectionStart = 0;
            this.mcLaurienOrderTextBox.Size = new System.Drawing.Size(75, 23);
            this.mcLaurienOrderTextBox.TabIndex = 29;
            this.mcLaurienOrderTextBox.TabStop = false;
            this.mcLaurienOrderTextBox.UseSystemPasswordChar = false;
            this.mcLaurienOrderTextBox.TextChanged += new System.EventHandler(this.mcLaurienOrderTextBox_TextChanged);
            // 
            // polynomialButton
            // 
            this.polynomialButton.AutoSize = true;
            this.polynomialButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.polynomialButton.Depth = 0;
            this.polynomialButton.Icon = null;
            this.polynomialButton.Location = new System.Drawing.Point(1621, 226);
            this.polynomialButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.polynomialButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.polynomialButton.Name = "polynomialButton";
            this.polynomialButton.Primary = false;
            this.polynomialButton.Size = new System.Drawing.Size(153, 36);
            this.polynomialButton.TabIndex = 30;
            this.polynomialButton.Text = "START POLYNOMIAL";
            this.polynomialButton.UseVisualStyleBackColor = true;
            this.polynomialButton.Click += new System.EventHandler(this.polynomialButton_Click);
            // 
            // calculateMcLaurienByLimitButton
            // 
            this.calculateMcLaurienByLimitButton.AutoSize = true;
            this.calculateMcLaurienByLimitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.calculateMcLaurienByLimitButton.Depth = 0;
            this.calculateMcLaurienByLimitButton.Icon = null;
            this.calculateMcLaurienByLimitButton.Location = new System.Drawing.Point(1638, 178);
            this.calculateMcLaurienByLimitButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.calculateMcLaurienByLimitButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.calculateMcLaurienByLimitButton.Name = "calculateMcLaurienByLimitButton";
            this.calculateMcLaurienByLimitButton.Primary = false;
            this.calculateMcLaurienByLimitButton.Size = new System.Drawing.Size(136, 36);
            this.calculateMcLaurienByLimitButton.TabIndex = 31;
            this.calculateMcLaurienByLimitButton.Text = "McLaurien Limit";
            this.calculateMcLaurienByLimitButton.UseVisualStyleBackColor = true;
            this.calculateMcLaurienByLimitButton.Click += new System.EventHandler(this.calculateMcLaurienByLimitButton_Click);
            // 
            // polynomialPointsListView
            // 
            this.polynomialPointsListView.FormattingEnabled = true;
            this.polynomialPointsListView.Location = new System.Drawing.Point(1533, 271);
            this.polynomialPointsListView.Name = "polynomialPointsListView";
            this.polynomialPointsListView.Size = new System.Drawing.Size(241, 212);
            this.polynomialPointsListView.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1787, 987);
            this.Controls.Add(this.polynomialPointsListView);
            this.Controls.Add(this.calculateMcLaurienByLimitButton);
            this.Controls.Add(this.polynomialButton);
            this.Controls.Add(this.mcLaurienOrderTextBox);
            this.Controls.Add(this.calculateMcLaurinSeriesButton);
            this.Controls.Add(this.panelPictureBox);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.integralPictureBox);
            this.Controls.Add(this.derivativePictureBox);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.functionPictureBox);
            this.Controls.Add(this.integrateButton);
            this.Controls.Add(this.integralInput);
            this.Controls.Add(this.infixFunctionLabel);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.xValueTextbox);
            this.Controls.Add(this.inputTextbox);
            this.Controls.Add(this.newtonRadioButton);
            this.Controls.Add(this.quotientRadioButton);
            this.Controls.Add(this.derivativeButton);
            this.Controls.Add(this.plotButton);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.plot);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.functionPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.derivativePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integralPictureBox)).EndInit();
            this.panelPictureBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OxyPlot.WindowsForms.PlotView plot;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFlatButton plotButton;
        private MaterialSkin.Controls.MaterialFlatButton derivativeButton;
        private MaterialSkin.Controls.MaterialRadioButton quotientRadioButton;
        private MaterialSkin.Controls.MaterialRadioButton newtonRadioButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField inputTextbox;
        private MaterialSkin.Controls.MaterialSingleLineTextField xValueTextbox;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel infixFunctionLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField integralInput;
        private MaterialSkin.Controls.MaterialFlatButton integrateButton;
        private System.Windows.Forms.PictureBox functionPictureBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.PictureBox derivativePictureBox;
        private System.Windows.Forms.PictureBox integralPictureBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.Panel panelPictureBox;
        private System.Windows.Forms.PictureBox graphPictureBox;
        private MaterialSkin.Controls.MaterialFlatButton calculateMcLaurinSeriesButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField mcLaurienOrderTextBox;
        private MaterialSkin.Controls.MaterialFlatButton polynomialButton;
        private MaterialSkin.Controls.MaterialFlatButton calculateMcLaurienByLimitButton;
        private System.Windows.Forms.ListBox polynomialPointsListView;
    }
}

