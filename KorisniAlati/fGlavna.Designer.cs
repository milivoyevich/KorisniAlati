namespace KorisniAlati
{
    partial class fGlavna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGlavna));
            this.txtKonekcija = new System.Windows.Forms.TextBox();
            this.btnKonekt = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnPoco = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPOCO = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkbView = new System.Windows.Forms.CheckBox();
            this.chkbProc = new System.Windows.Forms.CheckBox();
            this.chkbTable = new System.Windows.Forms.CheckBox();
            this.tpXML = new System.Windows.Forms.TabPage();
            this.btnObjavi = new System.Windows.Forms.Button();
            this.btnDodeli = new System.Windows.Forms.Button();
            this.btnScabb = new System.Windows.Forms.Button();
            this.btnXML = new System.Windows.Forms.Button();
            this.rbtxtXML = new System.Windows.Forms.RichTextBox();
            this.tpExcel = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.dgExcel = new System.Windows.Forms.DataGrid();
            this.tpBind = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.btnBind = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.linqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tpPOCO.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpXML.SuspendLayout();
            this.tpExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExcel)).BeginInit();
            this.tpBind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtKonekcija
            // 
            this.txtKonekcija.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtKonekcija.Location = new System.Drawing.Point(27, 20);
            this.txtKonekcija.Name = "txtKonekcija";
            this.txtKonekcija.Size = new System.Drawing.Size(399, 21);
            this.txtKonekcija.TabIndex = 0;
            // 
            // btnKonekt
            // 
            this.btnKonekt.Location = new System.Drawing.Point(445, 18);
            this.btnKonekt.Name = "btnKonekt";
            this.btnKonekt.Size = new System.Drawing.Size(75, 23);
            this.btnKonekt.TabIndex = 1;
            this.btnKonekt.Text = "Повежи се";
            this.btnKonekt.UseVisualStyleBackColor = true;
            this.btnKonekt.Click += new System.EventHandler(this.btnKonekt_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(36, 122);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(159, 225);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(225, 122);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(299, 221);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // btnPoco
            // 
            this.btnPoco.Location = new System.Drawing.Point(449, 349);
            this.btnPoco.Name = "btnPoco";
            this.btnPoco.Size = new System.Drawing.Size(75, 23);
            this.btnPoco.TabIndex = 4;
            this.btnPoco.Text = "POCO";
            this.btnPoco.UseVisualStyleBackColor = true;
            this.btnPoco.Click += new System.EventHandler(this.btnPoco_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPOCO);
            this.tabControl1.Controls.Add(this.tpXML);
            this.tabControl1.Controls.Add(this.tpExcel);
            this.tabControl1.Controls.Add(this.tpBind);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(587, 413);
            this.tabControl1.TabIndex = 5;
            // 
            // tpPOCO
            // 
            this.tpPOCO.BackColor = System.Drawing.Color.BurlyWood;
            this.tpPOCO.Controls.Add(this.groupBox1);
            this.tpPOCO.Controls.Add(this.listBox1);
            this.tpPOCO.Controls.Add(this.btnPoco);
            this.tpPOCO.Controls.Add(this.txtKonekcija);
            this.tpPOCO.Controls.Add(this.richTextBox1);
            this.tpPOCO.Controls.Add(this.btnKonekt);
            this.tpPOCO.Location = new System.Drawing.Point(4, 22);
            this.tpPOCO.Name = "tpPOCO";
            this.tpPOCO.Padding = new System.Windows.Forms.Padding(3);
            this.tpPOCO.Size = new System.Drawing.Size(579, 387);
            this.tpPOCO.TabIndex = 0;
            this.tpPOCO.Text = "POCO - LOKO";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkbView);
            this.groupBox1.Controls.Add(this.chkbProc);
            this.groupBox1.Controls.Add(this.chkbTable);
            this.groupBox1.Location = new System.Drawing.Point(39, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 56);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Објекти";
            // 
            // chkbView
            // 
            this.chkbView.AutoSize = true;
            this.chkbView.Location = new System.Drawing.Point(100, 24);
            this.chkbView.Name = "chkbView";
            this.chkbView.Size = new System.Drawing.Size(69, 17);
            this.chkbView.TabIndex = 2;
            this.chkbView.Text = "Погледи";
            this.chkbView.UseVisualStyleBackColor = true;
            // 
            // chkbProc
            // 
            this.chkbProc.AutoSize = true;
            this.chkbProc.Enabled = false;
            this.chkbProc.Location = new System.Drawing.Point(186, 24);
            this.chkbProc.Name = "chkbProc";
            this.chkbProc.Size = new System.Drawing.Size(82, 17);
            this.chkbProc.TabIndex = 1;
            this.chkbProc.Text = "Процедуре";
            this.chkbProc.UseVisualStyleBackColor = true;
            // 
            // chkbTable
            // 
            this.chkbTable.AutoSize = true;
            this.chkbTable.Checked = true;
            this.chkbTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbTable.Location = new System.Drawing.Point(23, 24);
            this.chkbTable.Name = "chkbTable";
            this.chkbTable.Size = new System.Drawing.Size(62, 17);
            this.chkbTable.TabIndex = 0;
            this.chkbTable.Text = "Табеле";
            this.chkbTable.UseVisualStyleBackColor = true;
            // 
            // tpXML
            // 
            this.tpXML.BackColor = System.Drawing.Color.LightSalmon;
            this.tpXML.Controls.Add(this.btnObjavi);
            this.tpXML.Controls.Add(this.btnDodeli);
            this.tpXML.Controls.Add(this.btnScabb);
            this.tpXML.Controls.Add(this.btnXML);
            this.tpXML.Controls.Add(this.rbtxtXML);
            this.tpXML.Location = new System.Drawing.Point(4, 22);
            this.tpXML.Name = "tpXML";
            this.tpXML.Padding = new System.Windows.Forms.Padding(3);
            this.tpXML.Size = new System.Drawing.Size(571, 387);
            this.tpXML.TabIndex = 1;
            this.tpXML.Text = "toXML";
            // 
            // btnObjavi
            // 
            this.btnObjavi.Location = new System.Drawing.Point(30, 216);
            this.btnObjavi.Name = "btnObjavi";
            this.btnObjavi.Size = new System.Drawing.Size(75, 23);
            this.btnObjavi.TabIndex = 4;
            this.btnObjavi.Text = "Objavi";
            this.btnObjavi.UseVisualStyleBackColor = true;
            this.btnObjavi.Click += new System.EventHandler(this.btnObjavi_Click);
            // 
            // btnDodeli
            // 
            this.btnDodeli.Location = new System.Drawing.Point(30, 177);
            this.btnDodeli.Name = "btnDodeli";
            this.btnDodeli.Size = new System.Drawing.Size(75, 23);
            this.btnDodeli.TabIndex = 3;
            this.btnDodeli.Text = "Dodeli";
            this.btnDodeli.UseVisualStyleBackColor = true;
            this.btnDodeli.Click += new System.EventHandler(this.btnDodeli_Click);
            // 
            // btnScabb
            // 
            this.btnScabb.Location = new System.Drawing.Point(30, 101);
            this.btnScabb.Name = "btnScabb";
            this.btnScabb.Size = new System.Drawing.Size(75, 23);
            this.btnScabb.TabIndex = 2;
            this.btnScabb.Text = "Servisi";
            this.btnScabb.UseVisualStyleBackColor = true;
            this.btnScabb.Click += new System.EventHandler(this.btnScabb_Click);
            // 
            // btnXML
            // 
            this.btnXML.Location = new System.Drawing.Point(30, 53);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(75, 23);
            this.btnXML.TabIndex = 1;
            this.btnXML.Text = "to XML";
            this.btnXML.UseVisualStyleBackColor = true;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // rbtxtXML
            // 
            this.rbtxtXML.Location = new System.Drawing.Point(208, 33);
            this.rbtxtXML.Name = "rbtxtXML";
            this.rbtxtXML.Size = new System.Drawing.Size(338, 323);
            this.rbtxtXML.TabIndex = 0;
            this.rbtxtXML.Text = "";
            // 
            // tpExcel
            // 
            this.tpExcel.BackColor = System.Drawing.Color.RosyBrown;
            this.tpExcel.Controls.Add(this.button2);
            this.tpExcel.Controls.Add(this.button1);
            this.tpExcel.Controls.Add(this.btnExportExcel);
            this.tpExcel.Controls.Add(this.btnExcel);
            this.tpExcel.Controls.Add(this.dgExcel);
            this.tpExcel.Location = new System.Drawing.Point(4, 22);
            this.tpExcel.Name = "tpExcel";
            this.tpExcel.Size = new System.Drawing.Size(571, 387);
            this.tpExcel.TabIndex = 2;
            this.tpExcel.Text = "Import to Excel";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(461, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 24);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Brown;
            this.button1.Location = new System.Drawing.Point(177, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Libre Office";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.MistyRose;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.ForeColor = System.Drawing.Color.Brown;
            this.btnExportExcel.Location = new System.Drawing.Point(23, 350);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(97, 23);
            this.btnExportExcel.TabIndex = 2;
            this.btnExportExcel.Text = "Извоз Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.BtnExportExcelClick);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.MistyRose;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.ForeColor = System.Drawing.Color.Brown;
            this.btnExcel.Location = new System.Drawing.Point(329, 350);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(97, 23);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.Text = "Увези Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.BtnExcelClick);
            // 
            // dgExcel
            // 
            this.dgExcel.DataMember = "";
            this.dgExcel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgExcel.Location = new System.Drawing.Point(23, 42);
            this.dgExcel.Name = "dgExcel";
            this.dgExcel.Size = new System.Drawing.Size(403, 273);
            this.dgExcel.TabIndex = 0;
            // 
            // tpBind
            // 
            this.tpBind.BackColor = System.Drawing.Color.Bisque;
            this.tpBind.Controls.Add(this.richTextBox2);
            this.tpBind.Controls.Add(this.btnBind);
            this.tpBind.Controls.Add(this.dataGrid1);
            this.tpBind.Location = new System.Drawing.Point(4, 22);
            this.tpBind.Name = "tpBind";
            this.tpBind.Size = new System.Drawing.Size(571, 387);
            this.tpBind.TabIndex = 3;
            this.tpBind.Text = "Binding";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox2.Location = new System.Drawing.Point(24, 23);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(193, 339);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // btnBind
            // 
            this.btnBind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBind.BackColor = System.Drawing.Color.PeachPuff;
            this.btnBind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBind.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnBind.Location = new System.Drawing.Point(468, 355);
            this.btnBind.Name = "btnBind";
            this.btnBind.Size = new System.Drawing.Size(84, 24);
            this.btnBind.TabIndex = 1;
            this.btnBind.Text = "Bind";
            this.btnBind.UseVisualStyleBackColor = false;
            this.btnBind.Click += new System.EventHandler(this.btnBind_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(236, 23);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(316, 326);
            this.dataGrid1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linqToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(587, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // linqToolStripMenuItem
            // 
            this.linqToolStripMenuItem.Name = "linqToolStripMenuItem";
            this.linqToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.linqToolStripMenuItem.Text = "Reports";
            this.linqToolStripMenuItem.Click += new System.EventHandler(this.linqToolStripMenuItem_Click);
            // 
            // fGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 437);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fGlavna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POCO - LOKO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPOCO.ResumeLayout(false);
            this.tpPOCO.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpXML.ResumeLayout(false);
            this.tpExcel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgExcel)).EndInit();
            this.tpBind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKonekcija;
        private System.Windows.Forms.Button btnKonekt;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnPoco;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPOCO;
        private System.Windows.Forms.TabPage tpXML;
        private System.Windows.Forms.Button btnXML;
        private System.Windows.Forms.RichTextBox rbtxtXML;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkbView;
        private System.Windows.Forms.CheckBox chkbProc;
        private System.Windows.Forms.CheckBox chkbTable;
        private System.Windows.Forms.TabPage tpExcel;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGrid dgExcel;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tpBind;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnBind;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem linqToolStripMenuItem;
        private System.Windows.Forms.Button btnScabb;
        private System.Windows.Forms.Button btnObjavi;
        private System.Windows.Forms.Button btnDodeli;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}

