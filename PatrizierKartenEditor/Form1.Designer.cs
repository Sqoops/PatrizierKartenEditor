namespace PatrizierKartenEditor
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
            // this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new CustomDataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonZoomOutMuch = new System.Windows.Forms.Button();
            this.buttonZoomInMuch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.RowTemplate.Height = 12;
            this.dataGridView1.Size = new System.Drawing.Size(1120, 408);
            this.dataGridView1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonZoomInMuch);
            this.splitContainer1.Panel1.Controls.Add(this.buttonZoomOutMuch);
            this.splitContainer1.Panel1.Controls.Add(this.buttonZoomIn);
            this.splitContainer1.Panel1.Controls.Add(this.buttonZoomOut);
            this.splitContainer1.Panel1.Controls.Add(this.buttonColor);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSave);
            this.splitContainer1.Panel1MinSize = 40;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1120, 452);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 3;
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.AutoSize = true;
            this.buttonZoomIn.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonZoomIn.Location = new System.Drawing.Point(300, 0);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(100, 40);
            this.buttonZoomIn.TabIndex = 5;
            this.buttonZoomIn.Text = "Größer";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.AutoSize = true;
            this.buttonZoomOut.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonZoomOut.Location = new System.Drawing.Point(200, 0);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(100, 40);
            this.buttonZoomOut.TabIndex = 4;
            this.buttonZoomOut.Text = "Kleiner";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // buttonColor
            // 
            this.buttonColor.AutoSize = true;
            this.buttonColor.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonColor.Location = new System.Drawing.Point(100, 0);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(100, 40);
            this.buttonColor.TabIndex = 3;
            this.buttonColor.Text = "Einfärben";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSize = true;
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonSave.Location = new System.Drawing.Point(0, 0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 40);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Speichern";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonZoomOutMuch
            // 
            this.buttonZoomOutMuch.AutoSize = true;
            this.buttonZoomOutMuch.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonZoomOutMuch.Location = new System.Drawing.Point(400, 0);
            this.buttonZoomOutMuch.Name = "buttonZoomOutMuch";
            this.buttonZoomOutMuch.Size = new System.Drawing.Size(100, 40);
            this.buttonZoomOutMuch.TabIndex = 6;
            this.buttonZoomOutMuch.Text = "Viel Kleiner";
            this.buttonZoomOutMuch.UseVisualStyleBackColor = true;
            this.buttonZoomOutMuch.Click += new System.EventHandler(this.buttonZoomOutMuch_Click);
            // 
            // buttonZoomInMuch
            // 
            this.buttonZoomInMuch.AutoSize = true;
            this.buttonZoomInMuch.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonZoomInMuch.Location = new System.Drawing.Point(500, 0);
            this.buttonZoomInMuch.Name = "buttonZoomInMuch";
            this.buttonZoomInMuch.Size = new System.Drawing.Size(100, 40);
            this.buttonZoomInMuch.TabIndex = 7;
            this.buttonZoomInMuch.Text = "Viel Größer";
            this.buttonZoomInMuch.UseVisualStyleBackColor = true;
            this.buttonZoomInMuch.Click += new System.EventHandler(this.buttonZoomInMuch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 452);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Patrizier Karteneditor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonZoomInMuch;
        private System.Windows.Forms.Button buttonZoomOutMuch;
    }
}

