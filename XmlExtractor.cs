using System;
using System.Globalization;
using System.Xml;

namespace ic_assessment
{
    public class XmlExtractor
    {

        public string InvoiceNo { get; }
        public string AccountNo { get; }
        public string CustomerName { get; }
        public string CycleCd { get; }
        public string BillDt { get; }
        public string DueDt { get; }
        public decimal BillAmount { get; }
        public decimal BalanceDue { get; }
        public string BillRunDt { get; }
        public string BillRunSeq { get; }
        public string BillRunTm { get; }
        public string BillTp { get; }
        public string MailingAddress1 { get; }
        public string MailingAddress2 { get; }
        public string City { get; }
        public string State { get; }
        public string Zip { get; }
        public string AccountClass { get; }

        public XmlExtractor(XmlNode billHeaderNode)
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";

            InvoiceNo = billHeaderNode["Invoice_No"].InnerText;
            AccountNo = billHeaderNode["Account_No"].InnerText;
            CustomerName = billHeaderNode["Customer_Name"].InnerText;
            CycleCd = billHeaderNode["Cycle_Cd"].InnerText;
            BillDt = billHeaderNode["Bill_Dt"].InnerText;
            DueDt = billHeaderNode["Due_Dt"].InnerText;
            BillAmount = decimal.Parse(billHeaderNode["Bill"]["Bill_Amount"].InnerText, numberFormatInfo);
            BalanceDue = decimal.Parse(billHeaderNode["Bill"]["Balance_Due"].InnerText, numberFormatInfo);
            BillRunDt = billHeaderNode["Bill"]["Bill_Run_Dt"].InnerText;
            BillRunSeq = billHeaderNode["Bill"]["Bill_Run_Seq"].InnerText;
            BillRunTm = billHeaderNode["Bill"]["Bill_Run_Tm"].InnerText;
            BillTp = billHeaderNode["Bill"]["Bill_Tp"].InnerText;
            MailingAddress1 = billHeaderNode["Address_Information"]["Mailing_Address_1"].InnerText;
            MailingAddress2 = billHeaderNode["Address_Information"]["Mailing_Address_2"].InnerText;
            City = billHeaderNode["Address_Information"]["City"].InnerText;
            State = billHeaderNode["Address_Information"]["State"].InnerText;
            Zip = billHeaderNode["Address_Information"]["Zip"].InnerText;
            AccountClass = billHeaderNode["Account_Class"].InnerText;
        }

        
    }
}

