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
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.frame;
using unoidl.com.sun.star.beans;
using unoidl.com.sun.star.sheet;
using unoidl.com.sun.star.container;
using unoidl.com.sun.star.table;
using unoidl.com.sun.star.text;
using unoidl.com.sun.star.uno;
using unoidl.com.sun.star.accessibility;

namespace KorisniAlati
{
    public partial class fGlavna : Form
    {
        public fGlavna()
        {
            InitializeComponent();
        }
        string initKonekt = @"Data Source=.\sqlexpress; Initial Catalog=AdventureWorks2012;User ID=sa; Password=vdm191100";
        SqlConnection konekcija = new SqlConnection();
        SqlCommand komanda=new SqlCommand(@"SELECT * FROM information_schema.tables where TABLE_TYPE='BASE TABLE'");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tabela, ttabla, tempt;
        DataSet ds=new DataSet();
        private void Form1_Load(object sender, EventArgs e)
        {
            txtKonekcija.Text = initKonekt;
        }

        private void btnKonekt_Click(object sender, EventArgs e)
        {
            komanda.CommandText = "";
            if (chkbTable.Checked) komanda.CommandText = @"SELECT 'table' as TIP, TABLE_SCHEMA+'.'+TABLE_NAME as Tabela FROM information_schema.tables where TABLE_TYPE='BASE TABLE'";
            if (chkbView.Checked)
            {
                if (komanda.CommandText.Length > 0) komanda.CommandText += " UNION ";
                komanda.CommandText += "SELECT 'view' as TIP, TABLE_SCHEMA+'.'+TABLE_NAME as Tabela FROM information_schema.views";
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
            listBox1.DisplayMember = "Tabela";
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
                ttabla = new DataTable(listBox1.Text.Substring(listBox1.Text.IndexOf(".")+1)); tempt = new DataTable();
                komanda.CommandText = "SELECT TOP 1 * FROM " + listBox1.Text + "";
                richTextBox1.AppendText("[Serializable]\n");
                richTextBox1.AppendText("public class " + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + "\n{\n");
                adapter.Fill(ttabla);
                komanda.CommandText = "Select name, type_name(user_type_id) as Type, is_nullable as Nullable from sys.all_columns" +
                " where object_id = OBJECT_ID('" + listBox1.Text + "')"; //
                adapter.Fill(tempt);
                richTextBox1.AppendText("#region Konstruktor\n\n");
                richTextBox1.AppendText("public " + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + "():base()\n{\n"+
                "      this.rowVersion = new byte[8];\n      SetNew();\n}\n");
                richTextBox1.AppendText("\n#endregion\n\n");
                richTextBox1.AppendText("#region Chlanovi\n\n");
                foreach (DataColumn kolona in ttabla.Columns)
                {
                  DataRow[] redovi= tempt.Select("name='" + kolona.ColumnName + "'");
                  if (redovi != null && redovi.Length == 1) moze_null = (bool)redovi[0]["Nullable"];
                    richTextBox1.AppendText("private " + kolona.DataType.Name + ((moze_null && kolona.DataType.Name.ToLower() != "string") ? "?" : "") + " _" + kolona.ColumnName + ";\n");
                }
                richTextBox1.AppendText("\nprotected byte[] rowVersion = null;\nprotected bool isNew = false;"+
                "\nprotected bool isDirty = false;\nprotected bool isDeleted = false;\n\n[NonSerialized]"+
                "\nprotected object originalValue = null;\n");
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
                        kolona.ColumnName + "=value;\n            SetDirty();\n         }\n      }\n}\n");
                }
                richTextBox1.AppendText("\n#endregion\n\n");
                richTextBox1.AppendText("#region nadjacane Osobine\n\n");
                richTextBox1.AppendText("public override bool IsDirty\n{\n      get { return this.isDirty; }\n}\n");
                richTextBox1.AppendText("\n#endregion\n\n");
                richTextBox1.AppendText("#region nadjacane Metode\n\n");
                richTextBox1.AppendText("public override void SetClean()\n{\n      this.isDirty = false;\n}\n");
                richTextBox1.AppendText("public override void SetOld()\n{\n      this.isNew = false;\n}\n");
                richTextBox1.AppendText("protected override object Copy(object src, object dst)\n{\n         "+
                 listBox1.Text + " from = (" + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + ")src;\n         "
             + listBox1.Text + " to = (" + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + ")dst;\n\n" +
            "         to.id = from.id;\n         to.sifra = from.sifra;\n         to.rowVersion = from.rowVersion;\n\n"+
            "         to.isNew = from.isNew;\n         to.isDirty = from.isDirty;\n         to.isDeleted = from.isDeleted;\n\n");
                foreach (DataColumn kolona in ttabla.Columns)
                {
                    richTextBox1.AppendText("         to._"+kolona.ColumnName+" = from._"+kolona.ColumnName+";\n");
                }
                richTextBox1.AppendText("\n         return dst;\n}\n");
                richTextBox1.AppendText("public override object Clone()\n      {\n         "+
                listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + " clone = (" + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + ")Copy(this, new " + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + "());" +
                "\n         return clone;\n      }\n");
                richTextBox1.AppendText("public override bool Validate(out string message)\n{\n      "+
                "bool validno = true;\n      message = string.Empty;\n      \n      return validno;\n}\n");
                richTextBox1.AppendText("\n#endregion\n\n");
                richTextBox1.AppendText("#region Jednachenja\n\n");
                richTextBox1.AppendText("public override int GetHashCode()\n{\n      return base.GetHashCode();\n}\n");
                richTextBox1.AppendText("public override bool Equals(object obj)\n{\n      "+
                    "if ((obj == null) || (GetType() != obj.GetType()))\n      {\n         return false;\n      }\n"+
                    "      " + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + " ps = (" + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + ")obj;\n      " +
                    "return this." + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + " == ps." + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + ";\n}\n");
                richTextBox1.AppendText("public static bool operator ==(" + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + " po1, " + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + " po2)\n" +
                    "{\n      if ((ReferenceEquals(po1, null)))\n      {\n         return ReferenceEquals(po2, null);\n"+
                    "      }\n      else\n      {\n         return po1.Equals(po2);\n      }\n}\n");
                richTextBox1.AppendText("public static bool operator !=(" + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + " po1, " + listBox1.Text.Substring(listBox1.Text.IndexOf(".") + 1) + " po2)\n" +
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
		void BtnExcelClick(object sender, EventArgs e)
		{
			if(	openFileDialog1.ShowDialog()==DialogResult.OK)
			{
				switch(openFileDialog1.SafeFileName.Substring(openFileDialog1.SafeFileName.IndexOf(".")+1).ToLower())
				{
					case "xls":	ds=ExcelImport.ImportExcelXLS(openFileDialog1.FileName,true);
							//int br=0;
//							foreach (DataTable dtt in ds.Tables ) {
//							dtt.TableName=dtt.TableName.Replace("$","");
//							//dtt.TableName="Strana"+(++br).ToString();
//							}
					break;
					case "xlsx": ds=ExcelImport.ImportExcelXLSX(openFileDialog1.FileName,true); break;
				default: 	Stream ss=File.OpenRead(openFileDialog1.FileName);
				ds=ExcelImport.ImportExcelXML(ss,true,false);		break;
				}		
		        foreach(DataTable tabela in  ds.Tables)
                {
                    foreach(DataRow red in tabela.Rows)
                    {
                        string sred = "";
                        foreach(object polje in red.ItemArray)
                        {
                            sred = sred + polje.ToString().Trim();
                        }
                        if (sred.Trim() == "") red.Delete();
                    }
                }
				dgExcel.DataSource=ds;
				openFileDialog1.Dispose();
			}
			
		}
		void BtnExportExcelClick(object sender, EventArgs e)
		{
			ExcelClass.exportToExcel(ds, "Proba.xml");
		}

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.FileName = "PPP.xls";
            sfd1.Filter = "(.xls)|Excel files";
            sfd1.DefaultExt = ".xls";
            if (sfd1.ShowDialog() == DialogResult.OK)
            {
                XComponentContext oStrap = uno.util.Bootstrap.bootstrap();
                XMultiServiceFactory oServMan = (XMultiServiceFactory)oStrap.getServiceManager();
                XComponentLoader desktop = (XComponentLoader)oServMan.createInstance("com.sun.star.frame.Desktop");
                string url = @"private:factory/scalc";
                PropertyValue[] loadProps = new PropertyValue[3];
                loadProps[0] = new PropertyValue();
                loadProps[0].Name = "Hidden";
                loadProps[0].Value = new uno.Any(true);
                loadProps[1] = new PropertyValue();
                loadProps[1].Name = "FilterName";
                loadProps[1].Value = new uno.Any("MS Excel 97");
                loadProps[2] = new PropertyValue();
                loadProps[2].Name = "ReadOnly";
                loadProps[2].Value = new uno.Any(false);
                XComponent document = desktop.loadComponentFromURL(url, "_blank", 0, loadProps);
                XSpreadsheets oSheets = ((XSpreadsheetDocument)document).getSheets();
                XIndexAccess oSheetsIA = (XIndexAccess)oSheets;
                XSpreadsheet sheet = (XSpreadsheet)oSheetsIA.getByIndex(0).Value;
                int ii = 0; XCell celija = null;
                foreach(DataColumn kol in ds.Tables[0].Columns){
                    celija = sheet.getCellByPosition(ii, 0);
                    ((XText)celija).setString(kol.ColumnName);
                    ((XPropertySet)celija).setPropertyValue("CellBackColor", new uno.Any(654321));
                    ((XPropertySet)celija).setPropertyValue("CharColor", new uno.Any(333444));
                    ii++;
                }
                ds.Tables[0].AcceptChanges(); ii = 0;
                foreach (DataRow red in ds.Tables[0].Rows)
                {
                    int jj = 0; ii++;
                    foreach (object ob in red.ItemArray)
                    {
                        celija = sheet.getCellByPosition(jj, ii);
                        ((XText)celija).setString(ob.ToString());
                        ((XPropertySet)celija).setPropertyValue("CellBackColor", new uno.Any(888777));
                        jj++;
                    }
                }             
                ((XStorable)document).storeToURL("file:///" + sfd1.FileName.Replace(@"\", "/"), loadProps);
                System.Diagnostics.Process.Start(sfd1.FileName);
            }
        }

        private void btnScabb_Click(object sender, EventArgs e)
        {
           MessageBox.Show( SCABB.SCABox.SetSCAVendorData("", ""));
        }

        private void btnBind_Click(object sender, EventArgs e)
        {
            Address fAdresa = new Address();
           MessageBox.Show( fAdresa.IsNew.ToString()+fAdresa.IsDirty.ToString()+fAdresa.IsDeleted.ToString());
          
        }

        private void linqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLinq forma = new fLinq();
            forma.ShowDialog();
        }
		
		
    }
}
