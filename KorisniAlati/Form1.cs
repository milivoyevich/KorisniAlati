using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

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
        DataTable tabela, ttabla, tempt;
        private void Form1_Load(object sender, EventArgs e)
        {
            txtKonekcija.Text = initKonekt;
        }

        private void btnKonekt_Click(object sender, EventArgs e)
        {
            komanda.CommandText = "";
            if (chkbTable.Checked) komanda.CommandText = @"SELECT 'table' as TIP, TABLE_NAME FROM information_schema.tables where TABLE_TYPE='BASE TABLE'";
            if (chkbView.Checked)
            {
                if (komanda.CommandText.Length > 0) komanda.CommandText += " UNION ";
                komanda.CommandText += "SELECT 'view' as TIP, TABLE_NAME FROM information_schema.views";
            }
            if (chkbProc.Checked)
            {
                if (komanda.CommandText.Length > 0) komanda.CommandText += " UNION ";
                komanda.CommandText += "SELECT 'proc' as TIP, ROUTINE_NAME as TABLE_NAME FROM information_schema.routines";
            }
            if(komanda.CommandText=="")
            {
                MessageBox.Show("Нисте изабрали ниједну врсту објеката!", "Упозорење"); return;
            }
            konekcija.ConnectionString = txtKonekcija.Text;
            komanda.Connection = konekcija;
            adapter.SelectCommand = komanda;
            tabela = new DataTable();
            adapter.Fill(tabela);
            listBox1.DataSource = null;
            listBox1.DataSource = tabela;
            listBox1.DisplayMember = "TABLE_NAME";
            //foreach (DataRow red in tabela.Rows)
            //{
            //    ttabla = new DataTable();
            //    komanda.CommandText = "SELECT TOP 1 * FROM ["+red["TABLE_NAME"].ToString()+"]";            
            //    richTextBox1.AppendText("public class "+red["TABLE_NAME"].ToString()+"\n{\n");
            //    adapter.Fill(ttabla);
            //    foreach(DataColumn kolona in ttabla.Columns)
            //    {
            //        richTextBox1.AppendText("public virtual "+ kolona.DataType.Name+" "+ kolona.ColumnName+ " {get; set; }\n");
            //    }
            //    richTextBox1.AppendText("}\n");
                
            //}
        }
        private void btnPoco_Click(object sender, EventArgs e)
        {
            bool moze_null = false;
            if (listBox1.SelectedIndex > -1)
            {
                ttabla = new DataTable(); tempt = new DataTable();
                komanda.CommandText = "SELECT TOP 1 * FROM [" + listBox1.Text + "]";
                richTextBox1.AppendText("[Serializable]\n");
                richTextBox1.AppendText("public class " + listBox1.Text + "\n{\n");
                adapter.Fill(ttabla);
                komanda.CommandText = "Select name, type_name(user_type_id) as Type, is_nullable as Nullable from sys.all_columns" +
                " where object_id = OBJECT_ID('" + listBox1.Text + "')"; //
                adapter.Fill(tempt);
                richTextBox1.AppendText("#region Konstruktor\n\n");
                richTextBox1.AppendText("public " + listBox1.Text + "():base()\n{\n}\n");
                richTextBox1.AppendText("\n#endregion\n\n");
                richTextBox1.AppendText("#region Chlanovi\n\n");
                foreach (DataColumn kolona in ttabla.Columns)
                {
                  DataRow[] redovi= tempt.Select("name='" + kolona.ColumnName + "'");
                  if (redovi != null && redovi.Length == 1) moze_null = (bool)redovi[0]["Nullable"];
                    richTextBox1.AppendText("private " + kolona.DataType.Name + ((moze_null && kolona.DataType.Name.ToLower() != "string") ? "?" : "") + " _" + kolona.ColumnName + ";\n");
                }
                richTextBox1.AppendText("\n#endregion\n\n");
                richTextBox1.AppendText("#region Osobine\n\n");
                foreach (DataColumn kolona in ttabla.Columns)
                {
                    DataRow[] redovi = tempt.Select("name='" + kolona.ColumnName + "'");
                    if (redovi != null && redovi.Length == 1) moze_null = (bool)redovi[0]["Nullable"];
                    richTextBox1.AppendText("public virtual " + kolona.DataType.Name + 
                        ((moze_null && kolona.DataType.Name.ToLower() != "string") ? "?" : "") + 
                        " " + kolona.ColumnName + " {\n      get { return _" + kolona.ColumnName + 
                        " ; }\n      set \n      {\n         if(_" + kolona.ColumnName + " != value)\n         {\n             _" + 
                        kolona.ColumnName + "=value;\n            SetDirty();\n         }\n      }\n");
                }
                richTextBox1.AppendText("\n#endregion\n\n");
                richTextBox1.AppendText("#region nadjacane Osobine\n\n");
                richTextBox1.AppendText("public override bool IsDirty\n{\n      get { return this.isDirty; }\n}\n");
                richTextBox1.AppendText("\n#endregion\n\n");
                richTextBox1.AppendText("#region nadjacane Metode\n\n");
                richTextBox1.AppendText("public override void SetClean()\n{\n      this.isDirty = false;\n}\n");
                richTextBox1.AppendText("public override void SetOld()\n{\n      this.isNew = false;\n}\n");
                richTextBox1.AppendText("protected override object Copy(object src, object dst)\n{\n         "+
                 listBox1.Text + " from = (" + listBox1.Text + ")src;\n         "
             + listBox1.Text + " to = (" + listBox1.Text + ")dst;\n\n"+
            "         to.id = from.id;\n         to.sifra = from.sifra;\n         to.rowVersion = from.rowVersion;\n\n"+
            "         to.isNew = from.isNew;\n         to.isDirty = from.isDirty;\n         to.isDeleted = from.isDeleted;\n\n");
                foreach (DataColumn kolona in ttabla.Columns)
                {
                    richTextBox1.AppendText("         to._"+kolona.ColumnName+" = from._"+kolona.ColumnName+";\n");
                }
                richTextBox1.AppendText("\n         return dst;\n}\n");
                richTextBox1.AppendText("public override object Clone()\n      {\n         "+
                listBox1.Text + " clone = (" + listBox1.Text + ")Copy(this, new " + listBox1.Text + "());" +
                "\n         return clone;\n      }\n");
                richTextBox1.AppendText("public override bool Validate(out string message)\n{\n      "+
                "bool validno = true;\n      message = string.Empty;\n      \n      return validno;\n}\n");
                richTextBox1.AppendText("\n#endregion\n\n");
                richTextBox1.AppendText("#region Jednachenja\n\n");
                richTextBox1.AppendText("public override int GetHashCode()\n{\n      return base.GetHashCode();\n}\n");
                richTextBox1.AppendText("public override bool Equals(object obj)\n{\n      "+
                    "if ((obj == null) || (GetType() != obj.GetType()))\n      {\n         return false;\n      }\n"+
                    "      " + listBox1.Text + " ps = (" + listBox1.Text + ")obj;\n      "+
                    "return this." + listBox1.Text + " == ps." + listBox1.Text + ";\n}\n");
                richTextBox1.AppendText("public static bool operator ==(" + listBox1.Text + " po1, " + listBox1.Text + " po2)\n" +
                    "{\n      if ((ReferenceEquals(po1, null)))\n      {\n         return ReferenceEquals(po2, null);\n"+
                    "      }\n      else\n      {\n         return po1.Equals(po2);\n      }\n}\n");
                richTextBox1.AppendText("public static bool operator !=(JciHdr po1, JciHdr po2)\n"+
                    "{\n      return !(po1 == po2);\n}\n");
                richTextBox1.AppendText("\n#endregion\n\n");
                richTextBox1.AppendText("}\n");
            }
        }

        private object Popuni_objekat(object objekat)
        {
            Type myType = objekat.GetType(); 
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
               // MessageBox.Show(prop.PropertyType.Name); 
               switch (prop.PropertyType.Name)
               {
                   case "String": prop.SetValue(objekat, "", null); break;
                   case "DateTime": prop.SetValue(objekat, DateTime.MinValue, null); break;
                   case "Int64":
                   case "Int32": //prop.SetValue(objekat, null, null); break;
                   case "Int16": break; //prop.SetValue(objekat, null, null);
                   case "Decimal": prop.SetValue(objekat, 0m, null); break;
                   case "Object":
                       //Type TipO = (Type)prop.ReflectedType.GetElementType();
                       //object objekat11 = Activator.CreateInstance(TipO);
                       
                       // prop.SetValue(objekat, Convert.ChangeType(objekat11, prop.ReflectedType.GetElementType()), null);
                       //    Type myType11 = objekat11.GetType();
                       //    IList<PropertyInfo> props11 = new List<PropertyInfo>(myType11.GetProperties());
                       //    if (props11.Count > 0) Popuni_objekat(objekat11);
                       break;
                   case "Boolean": break;
                   default: 
                       Type Tip = (Type)prop.PropertyType;
                       if (!prop.PropertyType.IsArray)
                       {
                           object objekat1 = Activator.CreateInstance(Tip);
                           prop.SetValue(objekat, Convert.ChangeType(objekat1, prop.PropertyType), null);
                           Type myType1 = objekat1.GetType();
                           IList<PropertyInfo> props1 = new List<PropertyInfo>(myType1.GetProperties());
                           if (props1.Count > 0) Popuni_objekat(objekat1);
                       }
                       else
                       {
                      //  MessageBox.Show(prop.PropertyType.GetElementType().Name,"Element");
                        object objekat1 = Activator.CreateInstance(Tip, new object[] {1});
                        prop.SetValue(objekat, Convert.ChangeType(objekat1, prop.PropertyType), null);
                        Type myType1 = objekat1.GetType();
                        IList<PropertyInfo> props1 = new List<PropertyInfo>(myType1.GetProperties());
                        if (props1.Count > 0) Popuni_objekat(objekat1);
                       }
                       break;
               }
                
            }
            return objekat;
        }
        private void btnXML_Click(object sender, EventArgs e)
        {
            //XmlDocument Dokument = new XmlDocument();
            CusDecMessage Dokument = new CusDecMessage();
            Dokument = (CusDecMessage)Popuni_objekat(Dokument);
            //Dokument.Header = new HeaderType();
            //Dokument.Header.SenderDetails = new HeaderTypeSenderDetails();
            //Dokument.Header.SenderDetails.IDAuthentication = new HeaderTypeSenderDetailsIDAuthentication();
            //Dokument.Header.SenderDetails.IDAuthentication.SenderID = "";
            //Dokument.Header.SenderDetails.Topic = "";
            //Dokument.Header.SenderDetails.Version = "";
            //Dokument.Body = new CusDecMessageBody();
            //Dokument.Body.MessageFunction = new CusDecMessageBodyMessageFunction[1];
            //Dokument.Body.MessageFunction[0] = new CusDecMessageBodyMessageFunction();
            //Dokument.Body.MessageHeader = new CusDecMessageBodyMessageHeader();

            //Type myType = Dokument.GetType();
            //IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            //foreach (PropertyInfo prop in props)
            //{
            //    Type Tip = (Type)prop.PropertyType;
            //    object objekat = Activator.CreateInstance(Tip);
            //    prop.SetValue(Dokument, Convert.ChangeType(objekat, prop.PropertyType), null);             
            //}
            

            XmlSerializer serijal = new XmlSerializer(typeof(CusDecMessage));          
             StringBuilder sb = new StringBuilder();
             XmlWriterSettings postavke = new XmlWriterSettings();
             postavke.Indent = true; postavke.OmitXmlDeclaration = false;
          
            XmlWriter writer = XmlWriter.Create(sb,postavke);
            var nsSer=new XmlSerializerNamespaces(); nsSer.Add (string.Empty,string.Empty);
            serijal.Serialize(writer, Dokument,nsSer);
            rbtxtXML.AppendText(sb.ToString());
        }
        
    }
}
