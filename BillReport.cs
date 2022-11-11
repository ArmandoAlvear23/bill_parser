using System.Text;
using System.Xml;

public partial class Program
{
    public class BillReport : Report
    {
        private const string NODE_HEADER = "BILL_HEADER";
        public string Report { get; private set; }
        public List<string> CustomerRecordList = new List<string>();
        public List<string> BillRecordList = new List<string>();
        public BillNodesProcessor BillProcessor { get; private set; }

        public BillReport(string docName)
        {
            XmlDocProcessor doc = new XmlDocProcessor(docName);

            XmlNodeList billNodes = doc.GetNodeListOfElement(NODE_HEADER);

            BillProcessor = new BillNodesProcessor(billNodes);
        }

        public override string GenerateReport()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine(GenerateHeader());
            report.AppendLine(GenerateBody());

            return report.ToString();
        }

        protected override string GenerateHeader()
        {
            StringBuilder header = new StringBuilder();

            HeaderRecordDict headerDict = new HeaderRecordDict(BillProcessor);

            foreach(var kvp in headerDict.HeaderKVP)
            {

                if(!String.IsNullOrEmpty(header.ToString()))
                {
                    header.Append("|");
                }

                header.Append($"{kvp.Key}~{kvp.Value}");
            }

            return header.ToString();
        }

        protected override string GenerateBody()
        {

            GenerateCustomerRecordList();
            GenerateBillRecordList();

            StringBuilder body = new StringBuilder();

            if (CustomerRecordList.Count == BillRecordList.Count)
            {
                for(int i = 0; i < CustomerRecordList.Count; i++)
                {
                    body.AppendLine(CustomerRecordList[i]);
                    body.AppendLine(BillRecordList[i]);
                }
            }

            return body.ToString();
        }


        private void GenerateCustomerRecordList()
        {
            List<Dictionary<string, string>> customerDictList = new CustomerRecordDict(BillProcessor).CustomerKVPList;

            foreach (var customerDict in customerDictList)
            {
                StringBuilder customerRecord = new StringBuilder();

                foreach (var kvp in customerDict)
                {

                    if (!String.IsNullOrEmpty(customerRecord.ToString()))
                    {
                        customerRecord.Append("|");
                    }

                    customerRecord.Append($"{kvp.Key}~{kvp.Value}");
                }

                CustomerRecordList.Add(customerRecord.ToString());
            }
        }

        private void GenerateBillRecordList()
        {
            List<Dictionary<string, string>> billDictList = new BillRecordDict(BillProcessor).BillKVPList;

            foreach (var billDict in billDictList)
            {
                StringBuilder billRecord = new StringBuilder();

                foreach (var kvp in billDict)
                {
                    if(!String.IsNullOrEmpty(billRecord.ToString()))
                    {
                        billRecord.Append("|");
                    }

                    billRecord.Append($"{kvp.Key}~{kvp.Value}");
                }

                BillRecordList.Add(billRecord.ToString());
            }
        }
    }

}