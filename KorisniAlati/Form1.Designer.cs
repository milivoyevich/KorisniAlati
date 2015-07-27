namespace KorisniAlati
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
            this.NORTHWNDDataSet = new KorisniAlati.NORTHWNDDataSet();
            this.tpPOCO = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkbView = new System.Windows.Forms.CheckBox();
            this.chkbProc = new System.Windows.Forms.CheckBox();
            this.chkbTable = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnPoco = new System.Windows.Forms.Button();
            this.txtKonekcija = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnKonekt = new System.Windows.Forms.Button();
            this.tpXML = new System.Windows.Forms.TabPage();
            this.btnXML = new System.Windows.Forms.Button();
            this.rbtxtXML = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.NORTHWNDDataSet)).BeginInit();
            this.tpPOCO.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpXML.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NORTHWNDDataSet
            // 
            this.NORTHWNDDataSet.DataSetName = "NORTHWNDDataSet";
            this.NORTHWNDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.tpPOCO.Size = new System.Drawing.Size(603, 394);
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
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(36, 122);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(159, 225);
            this.listBox1.TabIndex = 2;
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
            // txtKonekcija
            // 
            this.txtKonekcija.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtKonekcija.Location = new System.Drawing.Point(27, 20);
            this.txtKonekcija.Name = "txtKonekcija";
            this.txtKonekcija.Size = new System.Drawing.Size(399, 21);
            this.txtKonekcija.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(225, 122);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(299, 221);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
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
            // tpXML
            // 
            this.tpXML.BackColor = System.Drawing.Color.LightSalmon;
            this.tpXML.Controls.Add(this.btnXML);
            this.tpXML.Controls.Add(this.rbtxtXML);
            this.tpXML.Location = new System.Drawing.Point(4, 22);
            this.tpXML.Name = "tpXML";
            this.tpXML.Padding = new System.Windows.Forms.Padding(3);
            this.tpXML.Size = new System.Drawing.Size(603, 394);
            this.tpXML.TabIndex = 1;
            this.tpXML.Text = "toXML";
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPOCO);
            this.tabControl1.Controls.Add(this.tpXML);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(611, 420);
            this.tabControl1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 420);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POCO - LOKO";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NORTHWNDDataSet)).EndInit();
            this.tpPOCO.ResumeLayout(false);
            this.tpPOCO.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpXML.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NORTHWNDDataSet NORTHWNDDataSet;
        private System.Windows.Forms.TabPage tpPOCO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkbView;
        private System.Windows.Forms.CheckBox chkbProc;
        private System.Windows.Forms.CheckBox chkbTable;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnPoco;
        private System.Windows.Forms.TextBox txtKonekcija;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnKonekt;
        private System.Windows.Forms.TabPage tpXML;
        private System.Windows.Forms.Button btnXML;
        private System.Windows.Forms.RichTextBox rbtxtXML;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

