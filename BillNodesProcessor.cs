using System.Xml;
using ic_assessment;

public partial class Program
{
    public class BillNodesProcessor
    {
        public List<Account> Accounts = new List<Account>();

        public BillNodesProcessor(XmlNodeList billNodes)
        {
            foreach (XmlNode billNode in billNodes)
            {
                XmlExtractor xmlExt = new XmlExtractor(billNode);

                bool dupAccount = Accounts.Any(x => x.AccountNumber == xmlExt.AccountNo);

                if (dupAccount == false)
                {
                    Account account = CreateNewAccount(xmlExt);
                    Accounts.Add(account);
                }
                else
                {
                    Bill bill = CreateNewBill(xmlExt);
                    int index = Accounts.FindIndex(x => x.AccountNumber == xmlExt.AccountNo);
                    Accounts[index].bills.Add(bill);
                }
            }
        }

        private Account CreateNewAccount(XmlExtractor xmlExt)
        {
            Account account = new Account();
            account.AccountNumber = xmlExt.AccountNo;
            account.AccountClass = xmlExt.AccountClass;

            Customer customer = CreateNewCustomer(xmlExt);
            account.customer = customer;

            Bill bill = CreateNewBill(xmlExt);
            account.bills.Add(bill);

            return account;
        }

        private Address CreateNewAddress(XmlExtractor xmlExt)
        {
            return new Address(xmlExt.MailingAddress1,
                        xmlExt.MailingAddress2, xmlExt.City, xmlExt.State,
                        xmlExt.Zip);
        }

        private Customer CreateNewCustomer(XmlExtractor xmlExt)
        {
            Customer customer = new Customer(xmlExt.CustomerName);

            Address address = CreateNewAddress(xmlExt);
            customer.adresses.Add(address);

            return customer;
        }

        private Bill CreateNewBill(XmlExtractor xmlExt)
        {
            Bill bill = new Bill();

            bill.BillNumber = xmlExt.InvoiceNo;
            bill.CycleCd = xmlExt.CycleCd;
            bill.BillDate = xmlExt.BillDt;
            bill.DueDate = xmlExt.DueDt;
            bill.BillAmount = xmlExt.BillAmount;
            bill.BalanceDue = xmlExt.BalanceDue;
            bill.BillRunDate = xmlExt.BillRunDt;
            bill.BillRunSeq = xmlExt.BillRunSeq;
            bill.BillRunTime = xmlExt.BillRunTm;
            bill.BillType = xmlExt.BillTp;

            return bill;
        }

        public int GetInvoiceRecordCount()
        {
            int invoiceRecordCount = 0;

            foreach(var account in Accounts)
            {
                invoiceRecordCount += account.bills.Count;                
            }

            return Accounts.Count;
        }

        public decimal GetInvoiceRecordTotalAmount()
        {
            decimal sumAmount = 0.00M;

            foreach(var account in Accounts)
            {
                foreach(var bill in account.bills)
                {
                    sumAmount += bill.BillAmount;
                }
            }

            return sumAmount;
        }
    }

}