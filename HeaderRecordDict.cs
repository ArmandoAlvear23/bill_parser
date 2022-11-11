public partial class Program
{
    public class HeaderRecordDict : Dictionary
    {
        public Dictionary<string, string>? HeaderKVP { get; private set; }

        private BillNodesProcessor? BillNodesProcessor { get; set; }

        private const string ONE_VALUE = "FR";
        private const string TWO_VALUE = "8203ACC7-2094-43CC-8F7A-B8F19AA9BDA2";
        private const string THREE_VALUE = "SAMPLE UT FILE";

        public HeaderRecordDict(BillNodesProcessor? billNodesProcessor)
        {
            BillNodesProcessor = billNodesProcessor;
            Generate();
        }
        
        protected override void Generate()
        {
            Dictionary<string, string> headerKVP = new Dictionary<string, string>();

            headerKVP.Add("1", ONE_VALUE);
            headerKVP.Add("2", TWO_VALUE);
            headerKVP.Add("3", THREE_VALUE);
            headerKVP.Add("4", DateTime.Now.ToString("MM/dd/yyyy"));
            headerKVP.Add("5", BillNodesProcessor.GetInvoiceRecordCount().ToString());
            headerKVP.Add("6", BillNodesProcessor.GetInvoiceRecordTotalAmount().ToString());

            HeaderKVP = headerKVP;
        }
    }

}