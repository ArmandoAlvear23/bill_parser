public partial class Program
{
    public class BillRecordDict : Dictionary
    {
        public List<Dictionary<string, string>> BillKVPList = new List<Dictionary<string, string>>();

        private BillNodesProcessor? _billNodesProcessor { get; }

        public BillRecordDict(BillNodesProcessor? billNodesProcessor)
        {
            _billNodesProcessor = billNodesProcessor;

            Generate();
        }

        protected override void Generate()
        {
            List<Dictionary<string, string>> billKVPList = new List<Dictionary<string, string>>();

            foreach(var bnp in _billNodesProcessor.Accounts)
            {
                Dictionary<string, string> billKVP = new Dictionary<string, string>();

                string billDate = DateTime.Parse(new DateCorrector(bnp.bills[0].BillDate).CorrectedDate).ToString("MM/dd/yyyy");
                string dueDate = DateTime.Parse(new DateCorrector(bnp.bills[0].DueDate).CorrectedDate).ToString("MM/dd/yyyy");

                billKVP.Add("HH", bnp.bills[0].getHHVALUE());
                billKVP.Add("II", bnp.bills[0].getIIVALUE());
                billKVP.Add("JJ", bnp.bills[0].getJJVALUE());
                billKVP.Add("KK", bnp.AccountNumber);
                billKVP.Add("LL", billDate);
                billKVP.Add("MM", dueDate);
                billKVP.Add("NN", bnp.bills[0].BillAmount.ToString());
                billKVP.Add("OO", bnp.bills[0].getFirstNotificationDate());
                billKVP.Add("PP", bnp.bills[0].getSecondNotificationDate());
                billKVP.Add("QQ", bnp.bills[0].BalanceDue.ToString());
                billKVP.Add("RR", DateTime.Now.ToString("MM/dd/yyyy"));
                billKVP.Add("SS", new ServiceProvider().address.GetFullAddress());

                BillKVPList.Add(billKVP);
            }
        }

    }

}