using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KorisniAlati
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string initKonekt = @"Data Source=.\sqlexpress;Initial Catalog=NORTHWND;Integrated Security=True";
        SqlConnection konekcija = new SqlConnection();
        SqlCommand komanda=new SqlCommand(@"SELECT * FROM information_schema.tables where TABLE_TYPE='BASE TABLE'");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tabela, ttabla;
        private void Form1_Load(object sender, EventArgs e)
        {
            txtKonekcija.Text = initKonekt;
        }

        private void btnKonekt_Click(object sender, EventArgs e)
        {
            konekcija.ConnectionString = txtKonekcija.Text;
            komanda.Connection = konekcija;
            adapter.SelectCommand = komanda;
            tabela = new DataTable();
            adapter.Fill(tabela);
            listBox1.Items.Clear();
            listBox1.DataSource = tabela;
            listBox1.DisplayMember = "TABLE_NAME";
            foreach (DataRow red in tabela.Rows)
            {
                ttabla = new DataTable();
                komanda.CommandText = "SELECT TOP 1 * FROM ["+red["TABLE_NAME"].ToString()+"]";            
                richTextBox1.AppendText("public class "+red["TABLE_NAME"].ToString()+"\n{\n");
                adapter.Fill(ttabla);
                foreach(DataColumn kolona in ttabla.Columns)
                {
                    richTextBox1.AppendText("public virtual "+ kolona.DataType.Name+" "+ kolona.ColumnName+ " {get; set; }\n");
                }
                richTextBox1.AppendText("}\n");
                
            }
        }
    }
}
