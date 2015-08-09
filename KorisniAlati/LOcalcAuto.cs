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
    }
}
