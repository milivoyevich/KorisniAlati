using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KorisniAlati
{
    public partial class fReports : Form
    {
        public fReports()
        {
            InitializeComponent();
        }

        private void fLinq_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AdventureWorks2012DataSet.Person' table. You can move, or remove it, as needed.
            this.PersonTableAdapter.Fill(this.AdventureWorks2012DataSet.Person);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Microsoft.Reporting.WinForms.RenderingExtension bbb=null;
            //reportViewer1.ExportDialog(bbb);        
        }
    }
}
