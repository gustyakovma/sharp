namespace MPTCompare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblMpt2 = new System.Windows.Forms.Label();
            this.lblMpt1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnMPTLoad1 = new System.Windows.Forms.ToolStripButton();
            this.btnMPTLoad2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCompare = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cbTables = new System.Windows.Forms.ToolStripComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControlAct = new System.Windows.Forms.TabControl();
            this.tbAgregate = new System.Windows.Forms.TabPage();
            this.dgvAgregate = new System.Windows.Forms.DataGridView();
            this.tabGrid = new System.Windows.Forms.TabPage();
            this.trvTables = new System.Windows.Forms.TreeView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dg = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabArea = new System.Windows.Forms.TabPage();
            this.dgvArea = new System.Windows.Forms.DataGridView();
            this.btnGetRezim = new System.Windows.Forms.Button();
            this.tabRezim = new System.Windows.Forms.TabPage();
            this.dgvRezim = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControlAct.SuspendLayout();
            this.tbAgregate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgregate)).BeginInit();
            this.tabGrid.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.tabArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).BeginInit();
            this.tabRezim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezim)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 66);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnGetRezim);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.lblMpt2);
            this.panel3.Controls.Add(this.lblMpt1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(825, 41);
            this.panel3.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(657, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 3;
            this.button2.Text = "Построить дерево";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(738, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Загрузить Мегаточки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblMpt2
            // 
            this.lblMpt2.AutoSize = true;
            this.lblMpt2.Location = new System.Drawing.Point(3, 22);
            this.lblMpt2.Name = "lblMpt2";
            this.lblMpt2.Size = new System.Drawing.Size(35, 13);
            this.lblMpt2.TabIndex = 1;
            this.lblMpt2.Text = "label2";
            // 
            // lblMpt1
            // 
            this.lblMpt1.AutoSize = true;
            this.lblMpt1.Location = new System.Drawing.Point(3, 9);
            this.lblMpt1.Name = "lblMpt1";
            this.lblMpt1.Size = new System.Drawing.Size(35, 13);
            this.lblMpt1.TabIndex = 0;
            this.lblMpt1.Text = "label1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMPTLoad1,
            this.btnMPTLoad2,
            this.toolStripSeparator1,
            this.btnCompare,
            this.toolStripSeparator2,
            this.cbTables});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(825, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnMPTLoad1
            // 
            this.btnMPTLoad1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMPTLoad1.Image = ((System.Drawing.Image)(resources.GetObject("btnMPTLoad1.Image")));
            this.btnMPTLoad1.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnMPTLoad1.Name = "btnMPTLoad1";
            this.btnMPTLoad1.Size = new System.Drawing.Size(23, 22);
            this.btnMPTLoad1.Text = "toolStripButton1";
            this.btnMPTLoad1.ToolTipText = "Загрузить первую мегаточку";
            this.btnMPTLoad1.Click += new System.EventHandler(this.btnMPTLoad1_Click);
            // 
            // btnMPTLoad2
            // 
            this.btnMPTLoad2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMPTLoad2.Image = ((System.Drawing.Image)(resources.GetObject("btnMPTLoad2.Image")));
            this.btnMPTLoad2.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnMPTLoad2.Name = "btnMPTLoad2";
            this.btnMPTLoad2.Size = new System.Drawing.Size(23, 22);
            this.btnMPTLoad2.Text = "toolStripButton2";
            this.btnMPTLoad2.ToolTipText = "Загрузить вторую мегаточку";
            this.btnMPTLoad2.Click += new System.EventHandler(this.btnMPTLoad2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCompare
            // 
            this.btnCompare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCompare.Enabled = false;
            this.btnCompare.Image = ((System.Drawing.Image)(resources.GetObject("btnCompare.Image")));
            this.btnCompare.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(23, 22);
            this.btnCompare.Text = "toolStripButton1";
            this.btnCompare.ToolTipText = "Сравнить мегаточки";
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cbTables
            // 
            this.cbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(121, 25);
            this.cbTables.SelectedIndexChanged += new System.EventHandler(this.cbTables_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControlAct);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 550);
            this.panel2.TabIndex = 5;
            // 
            // tabControlAct
            // 
            this.tabControlAct.Controls.Add(this.tabRezim);
            this.tabControlAct.Controls.Add(this.tabArea);
            this.tabControlAct.Controls.Add(this.tbAgregate);
            this.tabControlAct.Controls.Add(this.tabGrid);
            this.tabControlAct.Controls.Add(this.tabPage1);
            this.tabControlAct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControlAct.Location = new System.Drawing.Point(0, -3);
            this.tabControlAct.Name = "tabControlAct";
            this.tabControlAct.SelectedIndex = 0;
            this.tabControlAct.Size = new System.Drawing.Size(825, 553);
            this.tabControlAct.TabIndex = 4;
            // 
            // tbAgregate
            // 
            this.tbAgregate.Controls.Add(this.dgvAgregate);
            this.tbAgregate.Location = new System.Drawing.Point(4, 22);
            this.tbAgregate.Name = "tbAgregate";
            this.tbAgregate.Padding = new System.Windows.Forms.Padding(3);
            this.tbAgregate.Size = new System.Drawing.Size(817, 527);
            this.tbAgregate.TabIndex = 1;
            this.tbAgregate.Text = "Агрегаты";
            this.tbAgregate.UseVisualStyleBackColor = true;
            // 
            // dgvAgregate
            // 
            this.dgvAgregate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgregate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAgregate.Location = new System.Drawing.Point(3, 0);
            this.dgvAgregate.Name = "dgvAgregate";
            this.dgvAgregate.Size = new System.Drawing.Size(811, 524);
            this.dgvAgregate.TabIndex = 0;
            // 
            // tabGrid
            // 
            this.tabGrid.Controls.Add(this.trvTables);
            this.tabGrid.Location = new System.Drawing.Point(4, 22);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Size = new System.Drawing.Size(817, 527);
            this.tabGrid.TabIndex = 2;
            this.tabGrid.Text = "Grid";
            this.tabGrid.UseVisualStyleBackColor = true;
            // 
            // trvTables
            // 
            this.trvTables.Location = new System.Drawing.Point(8, 26);
            this.trvTables.Name = "trvTables";
            this.trvTables.Size = new System.Drawing.Size(426, 332);
            this.trvTables.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dg);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(817, 527);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dg
            // 
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column3,
            this.Column6});
            this.dg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dg.Location = new System.Drawing.Point(3, 149);
            this.dg.Name = "dg";
            this.dg.RowHeadersVisible = false;
            this.dg.Size = new System.Drawing.Size(811, 375);
            this.dg.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Таблица";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Характеристика";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Мегаточка 1";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Мегаточка 2";
            this.Column5.Name = "Column5";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            // 
            // tabArea
            // 
            this.tabArea.Controls.Add(this.dgvArea);
            this.tabArea.Location = new System.Drawing.Point(4, 22);
            this.tabArea.Name = "tabArea";
            this.tabArea.Size = new System.Drawing.Size(817, 527);
            this.tabArea.TabIndex = 3;
            this.tabArea.Text = "Территории";
            this.tabArea.UseVisualStyleBackColor = true;
            // 
            // dgvArea
            // 
            this.dgvArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvArea.Location = new System.Drawing.Point(0, 3);
            this.dgvArea.Name = "dgvArea";
            this.dgvArea.Size = new System.Drawing.Size(817, 524);
            this.dgvArea.TabIndex = 0;
            // 
            // btnGetRezim
            // 
            this.btnGetRezim.Location = new System.Drawing.Point(560, 3);
            this.btnGetRezim.Name = "btnGetRezim";
            this.btnGetRezim.Size = new System.Drawing.Size(63, 35);
            this.btnGetRezim.TabIndex = 4;
            this.btnGetRezim.Text = "Режим";
            this.btnGetRezim.UseVisualStyleBackColor = true;
            this.btnGetRezim.Click += new System.EventHandler(this.btnGetRezim_Click);
            // 
            // tabRezim
            // 
            this.tabRezim.Controls.Add(this.dgvRezim);
            this.tabRezim.Location = new System.Drawing.Point(4, 22);
            this.tabRezim.Name = "tabRezim";
            this.tabRezim.Size = new System.Drawing.Size(817, 527);
            this.tabRezim.TabIndex = 4;
            this.tabRezim.Text = "Режим";
            this.tabRezim.UseVisualStyleBackColor = true;
            // 
            // dgvRezim
            // 
            this.dgvRezim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRezim.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvRezim.Location = new System.Drawing.Point(0, 3);
            this.dgvRezim.Name = "dgvRezim";
            this.dgvRezim.Size = new System.Drawing.Size(817, 524);
            this.dgvRezim.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 616);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Сравнение мегаточек";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControlAct.ResumeLayout(false);
            this.tbAgregate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgregate)).EndInit();
            this.tabGrid.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.tabArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).EndInit();
            this.tabRezim.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezim)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnMPTLoad1;
        private System.Windows.Forms.ToolStripButton btnMPTLoad2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCompare;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMpt2;
        private System.Windows.Forms.Label lblMpt1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox cbTables;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControlAct;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tbAgregate;
        private System.Windows.Forms.DataGridView dgvAgregate;
        private System.Windows.Forms.TabPage tabGrid;
        private System.Windows.Forms.TreeView trvTables;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabArea;
        private System.Windows.Forms.DataGridView dgvArea;
        private System.Windows.Forms.Button btnGetRezim;
        private System.Windows.Forms.TabPage tabRezim;
        private System.Windows.Forms.DataGridView dgvRezim;

    }
}

