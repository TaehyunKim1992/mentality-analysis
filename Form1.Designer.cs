namespace PaintProgram
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새로만들기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도형ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Circle = new System.Windows.Forms.ToolStripMenuItem();
            this.Square = new System.Windows.Forms.ToolStripMenuItem();
            this.Line = new System.Windows.Forms.ToolStripMenuItem();
            this.선굵기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linewidth1 = new System.Windows.Forms.ToolStripMenuItem();
            this.linewidth3 = new System.Windows.Forms.ToolStripMenuItem();
            this.linewidth5 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sltColor = new System.Windows.Forms.PictureBox();
            this.boxRed = new System.Windows.Forms.PictureBox();
            this.boxOrange = new System.Windows.Forms.PictureBox();
            this.boxYellow = new System.Windows.Forms.PictureBox();
            this.boxGreen = new System.Windows.Forms.PictureBox();
            this.boxBlue = new System.Windows.Forms.PictureBox();
            this.boxNavy = new System.Windows.Forms.PictureBox();
            this.boxPurple = new System.Windows.Forms.PictureBox();
            this.boxBlack = new System.Windows.Forms.PictureBox();
            this.boxWhite = new System.Windows.Forms.PictureBox();
            this.colorEdit = new System.Windows.Forms.PictureBox();
            this.아동심리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.분석ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sltColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxOrange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxNavy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxPurple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.도형ToolStripMenuItem,
            this.선굵기ToolStripMenuItem,
            this.분석ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(1044, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.저장ToolStripMenuItem,
            this.열기ToolStripMenuItem,
            this.새로만들기ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.저장ToolStripMenuItem.Text = "저장";
            this.저장ToolStripMenuItem.Click += new System.EventHandler(this.저장ToolStripMenuItem_Click);
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.열기ToolStripMenuItem.Text = "열기";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // 새로만들기ToolStripMenuItem
            // 
            this.새로만들기ToolStripMenuItem.Name = "새로만들기ToolStripMenuItem";
            this.새로만들기ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.새로만들기ToolStripMenuItem.Text = "새로만들기";
            this.새로만들기ToolStripMenuItem.Click += new System.EventHandler(this.새로만들기ToolStripMenuItem_Click);
            // 
            // 도형ToolStripMenuItem
            // 
            this.도형ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Circle,
            this.Square,
            this.Line});
            this.도형ToolStripMenuItem.Name = "도형ToolStripMenuItem";
            this.도형ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.도형ToolStripMenuItem.Text = "도형";
            // 
            // Circle
            // 
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(152, 22);
            this.Circle.Text = "원";
            this.Circle.Click += new System.EventHandler(this.Circle_Click);
            // 
            // Square
            // 
            this.Square.Name = "Square";
            this.Square.Size = new System.Drawing.Size(152, 22);
            this.Square.Text = "사각형";
            this.Square.Click += new System.EventHandler(this.Square_Click);
            // 
            // Line
            // 
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(152, 22);
            this.Line.Text = "선";
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // 선굵기ToolStripMenuItem
            // 
            this.선굵기ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linewidth1,
            this.linewidth3,
            this.linewidth5});
            this.선굵기ToolStripMenuItem.Name = "선굵기ToolStripMenuItem";
            this.선굵기ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.선굵기ToolStripMenuItem.Text = "선굵기";
            // 
            // linewidth1
            // 
            this.linewidth1.Name = "linewidth1";
            this.linewidth1.Size = new System.Drawing.Size(152, 22);
            this.linewidth1.Text = "얇게";
            this.linewidth1.Click += new System.EventHandler(this.linewidth1_Click);
            // 
            // linewidth3
            // 
            this.linewidth3.Name = "linewidth3";
            this.linewidth3.Size = new System.Drawing.Size(152, 22);
            this.linewidth3.Text = "보통";
            this.linewidth3.Click += new System.EventHandler(this.linewidth3_Click);
            // 
            // linewidth5
            // 
            this.linewidth5.Name = "linewidth5";
            this.linewidth5.Size = new System.Drawing.Size(152, 22);
            this.linewidth5.Text = "굵게";
            this.linewidth5.Click += new System.EventHandler(this.linewidth5_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "색 편집";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "현재색";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.sltColor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.boxRed, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.boxOrange, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.boxYellow, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.boxGreen, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.boxBlue, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.boxNavy, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.boxPurple, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.boxBlack, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.boxWhite, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.colorEdit, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(54, 556);
            this.tableLayoutPanel1.TabIndex = 13;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(972, 561);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 14;
            this.chart1.Text = "chart1";
            // 
            // sltColor
            // 
            this.sltColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sltColor.BackColor = System.Drawing.Color.Black;
            this.sltColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sltColor.Location = new System.Drawing.Point(9, 2);
            this.sltColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sltColor.Name = "sltColor";
            this.sltColor.Size = new System.Drawing.Size(35, 32);
            this.sltColor.TabIndex = 13;
            this.sltColor.TabStop = false;
            // 
            // boxRed
            // 
            this.boxRed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxRed.BackColor = System.Drawing.Color.Red;
            this.boxRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxRed.Location = new System.Drawing.Point(9, 145);
            this.boxRed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxRed.Name = "boxRed";
            this.boxRed.Size = new System.Drawing.Size(35, 33);
            this.boxRed.TabIndex = 6;
            this.boxRed.TabStop = false;
            this.boxRed.Click += new System.EventHandler(this.boxRed_Click);
            // 
            // boxOrange
            // 
            this.boxOrange.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxOrange.BackColor = System.Drawing.Color.Orange;
            this.boxOrange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxOrange.Location = new System.Drawing.Point(9, 182);
            this.boxOrange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxOrange.Name = "boxOrange";
            this.boxOrange.Size = new System.Drawing.Size(35, 31);
            this.boxOrange.TabIndex = 8;
            this.boxOrange.TabStop = false;
            this.boxOrange.Click += new System.EventHandler(this.boxOrange_Click);
            // 
            // boxYellow
            // 
            this.boxYellow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxYellow.BackColor = System.Drawing.Color.Yellow;
            this.boxYellow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxYellow.Location = new System.Drawing.Point(9, 217);
            this.boxYellow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxYellow.Name = "boxYellow";
            this.boxYellow.Size = new System.Drawing.Size(35, 31);
            this.boxYellow.TabIndex = 7;
            this.boxYellow.TabStop = false;
            this.boxYellow.Click += new System.EventHandler(this.boxYellow_Click);
            // 
            // boxGreen
            // 
            this.boxGreen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxGreen.BackColor = System.Drawing.Color.Green;
            this.boxGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxGreen.Location = new System.Drawing.Point(9, 252);
            this.boxGreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxGreen.Name = "boxGreen";
            this.boxGreen.Size = new System.Drawing.Size(35, 31);
            this.boxGreen.TabIndex = 7;
            this.boxGreen.TabStop = false;
            this.boxGreen.Click += new System.EventHandler(this.boxGreen_Click);
            // 
            // boxBlue
            // 
            this.boxBlue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxBlue.BackColor = System.Drawing.Color.Blue;
            this.boxBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxBlue.Location = new System.Drawing.Point(9, 287);
            this.boxBlue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxBlue.Name = "boxBlue";
            this.boxBlue.Size = new System.Drawing.Size(35, 31);
            this.boxBlue.TabIndex = 7;
            this.boxBlue.TabStop = false;
            this.boxBlue.Click += new System.EventHandler(this.boxBlue_Click);
            // 
            // boxNavy
            // 
            this.boxNavy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxNavy.BackColor = System.Drawing.Color.Navy;
            this.boxNavy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxNavy.Location = new System.Drawing.Point(9, 322);
            this.boxNavy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxNavy.Name = "boxNavy";
            this.boxNavy.Size = new System.Drawing.Size(35, 31);
            this.boxNavy.TabIndex = 14;
            this.boxNavy.TabStop = false;
            this.boxNavy.Click += new System.EventHandler(this.boxNavy_Click);
            // 
            // boxPurple
            // 
            this.boxPurple.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxPurple.BackColor = System.Drawing.Color.Purple;
            this.boxPurple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxPurple.Location = new System.Drawing.Point(9, 357);
            this.boxPurple.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxPurple.Name = "boxPurple";
            this.boxPurple.Size = new System.Drawing.Size(35, 31);
            this.boxPurple.TabIndex = 7;
            this.boxPurple.TabStop = false;
            this.boxPurple.Click += new System.EventHandler(this.boxPink_Click);
            // 
            // boxBlack
            // 
            this.boxBlack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxBlack.BackColor = System.Drawing.Color.Black;
            this.boxBlack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxBlack.Location = new System.Drawing.Point(9, 392);
            this.boxBlack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxBlack.Name = "boxBlack";
            this.boxBlack.Size = new System.Drawing.Size(35, 31);
            this.boxBlack.TabIndex = 3;
            this.boxBlack.TabStop = false;
            this.boxBlack.Click += new System.EventHandler(this.boxBlack_Click);
            // 
            // boxWhite
            // 
            this.boxWhite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.boxWhite.BackColor = System.Drawing.Color.White;
            this.boxWhite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxWhite.Location = new System.Drawing.Point(9, 427);
            this.boxWhite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boxWhite.Name = "boxWhite";
            this.boxWhite.Size = new System.Drawing.Size(35, 31);
            this.boxWhite.TabIndex = 4;
            this.boxWhite.TabStop = false;
            this.boxWhite.Click += new System.EventHandler(this.boxWhite_Click);
            // 
            // colorEdit
            // 
            this.colorEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.colorEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorEdit.Image = ((System.Drawing.Image)(resources.GetObject("colorEdit.Image")));
            this.colorEdit.InitialImage = null;
            this.colorEdit.Location = new System.Drawing.Point(7, 56);
            this.colorEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit.Name = "colorEdit";
            this.colorEdit.Size = new System.Drawing.Size(40, 40);
            this.colorEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.colorEdit.TabIndex = 5;
            this.colorEdit.TabStop = false;
            this.colorEdit.Click += new System.EventHandler(this.colorEdit_click);
            // 
            // 아동심리ToolStripMenuItem
            // 
            this.아동심리ToolStripMenuItem.Name = "아동심리ToolStripMenuItem";
            this.아동심리ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.아동심리ToolStripMenuItem.Text = "아동심리 분석";
            this.아동심리ToolStripMenuItem.Click += new System.EventHandler(this.아동심리ToolStripMenuItem_Click_1);
            // 
            // 분석ToolStripMenuItem
            // 
            this.분석ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.아동심리ToolStripMenuItem});
            this.분석ToolStripMenuItem.Name = "분석ToolStripMenuItem";
            this.분석ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.분석ToolStripMenuItem.Text = "분석";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1044, 606);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "제목 없음 - 그림판";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sltColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxOrange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxNavy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxPurple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새로만들기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 선굵기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linewidth1;
        private System.Windows.Forms.ToolStripMenuItem linewidth3;
        private System.Windows.Forms.ToolStripMenuItem linewidth5;
        private System.Windows.Forms.ToolStripMenuItem 도형ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Circle;
        private System.Windows.Forms.ToolStripMenuItem Square;
        private System.Windows.Forms.ToolStripMenuItem Line;
        private System.Windows.Forms.PictureBox boxBlack;
        private System.Windows.Forms.PictureBox boxOrange;
        private System.Windows.Forms.PictureBox boxYellow;
        private System.Windows.Forms.PictureBox boxBlue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox boxRed;
        private System.Windows.Forms.PictureBox boxPurple;
        private System.Windows.Forms.PictureBox boxWhite;
        private System.Windows.Forms.PictureBox colorEdit;
        private System.Windows.Forms.PictureBox boxGreen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox sltColor;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox boxNavy;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem 분석ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 아동심리ToolStripMenuItem;
    }
}

