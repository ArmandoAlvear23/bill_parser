public partial class Program
{
    public class CustomerRecordDict : Dictionary
    {
        public List<Dictionary<string, string>> CustomerKVPList = new List<Dictionary<string, string>>();

        private BillNodesProcessor? _billNodesProcessor { get; }

        private const string AA_VALUE = "FR";

        public CustomerRecordDict(BillNodesProcessor? billNodesProcessor)
        { 
            _billNodesProcessor = billNodesProcessor;

            Generate();  
        }

        protected override void Generate()
        {
            foreach (var bnp in _billNodesProcessor.Accounts)
            {
                Dictionary<string, string> customerKVP = new Dictionary<string, string>();

                customerKVP.Add("AA", AA_VALUE);
                customerKVP.Add("BB", bnp.AccountNumber);
                customerKVP.Add("VV", bnp.customer.FullName);
                customerKVP.Add("CC", bnp.customer.adresses[0].MailingAddress1);
                customerKVP.Add("DD", bnp.customer.adresses[0].MailingAddress2);
                customerKVP.Add("EE", bnp.customer.adresses[0].City);
                customerKVP.Add("FF", bnp.customer.adresses[0].State);
                customerKVP.Add("GG", bnp.customer.adresses[0].Zip);

                CustomerKVPList.Add(customerKVP);
            }
        }
    }

}