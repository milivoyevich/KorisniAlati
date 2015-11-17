using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.frame;
using unoidl.com.sun.star.beans;
using unoidl.com.sun.star.sheet;
using unoidl.com.sun.star.container;
using unoidl.com.sun.star.table;
using unoidl.com.sun.star.text;
using unoidl.com.sun.star.uno;
using unoidl.com.sun.star.accessibility;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using AutoMapper;

namespace KorisniAlati
{
    class LOcalcAuto
    {
        private const string fileName =
     @"file:///C:/Documents and Settings/My Documents/Hours Report.ods";

        //Concrete Methods
        internal XComponent openCalcSheet()
        {
            XComponentContext oStrap = uno.util.Bootstrap.bootstrap();
            XMultiServiceFactory oServMan = (XMultiServiceFactory)oStrap.getServiceManager();
            XComponentLoader desktop = (XComponentLoader)oServMan.createInstance("com.sun.star.frame.Desktop");
            string url = @"private:factory/scalc";
            PropertyValue[] loadProps = new PropertyValue[1];
            loadProps[0] = new PropertyValue();
            loadProps[0].Name = "Hidden";
            loadProps[0].Value = new uno.Any(true);
            //PropertyValue[] loadProps = new PropertyValue[0];
            XComponent document = desktop.loadComponentFromURL(url, "_blank", 0, loadProps);
            return document;
        }

        public void writeToSheet(XComponent document)
        {
            XSpreadsheets oSheets = ((XSpreadsheetDocument)document).getSheets();
            XIndexAccess oSheetsIA = (XIndexAccess)oSheets;
            XSpreadsheet sheet = (XSpreadsheet)oSheetsIA.getByIndex(0).Value;
            XCell cell = sheet.getCellByPosition(0, 0); //A1
            ((XText)cell).setString("Cost");
            cell = sheet.getCellByPosition(1, 0); //B1
            cell.setValue(200);
            cell = sheet.getCellByPosition(1, 2); //B3
            cell.setFormula("=B1 * 1.175");
        }

        public void saveCalcSheet(XComponent oDoc)
        {
            PropertyValue[] propVals = new PropertyValue[1];
            propVals[0] = new PropertyValue();
            propVals[0].Name = "FilterName";
            propVals[0].Value = new uno.Any("calc8");
            ((XStorable)oDoc).storeToURL(fileName, propVals);
        }

       
      
       
        public List<Address> PersonaL()
        {
            List<Address> adrese = new List<Address>();
            SqlConnection konekcija = new SqlConnection( @"Data Source=MILIVOYEVICH-PC; Initial Catalog=AdventureWorks2012;User ID=sa; Password=vdm191100");
            //SqlConnection konekcija = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=AdventureWorks2012;Integrated Security=True");
            SqlCommand komanda = new SqlCommand("Select * from Person.Address", konekcija);
            konekcija.Open();
            using (konekcija)
            {
                SqlDataReader reader = komanda.ExecuteReader();
                adrese = new List<Address>().FromDataReader(reader).ToList();
            }
            return adrese;
        }
    }
    public class Reflection
    {
        public void FillObjectWithProperty(ref object objectTo, string propertyName, object propertyValue)
        {
            Type tOb2 = objectTo.GetType();
            tOb2.GetProperty(propertyName).SetValue(objectTo, propertyValue == DBNull.Value ? null : propertyValue, null);
        }
    }
    public static class IENumerableExtensions
    {
        public static IEnumerable<Address> FromDataReader<Address>(this IEnumerable<Address> list, SqlDataReader dr)
        {
            Reflection reflec = new Reflection();
            Object instance;
            List<Object> lstObj = new List<Object>();
            while (dr.Read())
            {
                instance = Activator.CreateInstance(list.GetType().GetGenericArguments()[0]);
                foreach (DataRow drow in dr.GetSchemaTable().Rows)
                {
                    reflec.FillObjectWithProperty(ref instance,
                            drow.ItemArray[0].ToString(), dr[drow.ItemArray[0].ToString()]);
                }
                lstObj.Add(instance);
            }
            List<Address> lstResult = new List<Address>();
            foreach (Object item in lstObj)
            {
                lstResult.Add((Address)Convert.ChangeType(item, typeof(Address)));
            }
            return lstResult;
        }
    }
}
