public partial class Program
{
    public class Bill
    {
        public const string HH_VALUE = "IH"; 
        public const string II_VALUE = "R";
        public const string JJ_VALUE = "8E2FEA69-5D77-4D0F-898E-DFA25677D19E";
        public string? BillNumber { get; set; }
        public string? CycleCd { get; set; }
        public string? BillDate { get; set; }
        public string? DueDate { get; set; }
        public decimal BillAmount { get; set; }
        public decimal BalanceDue { get; set; }
        public string? BillRunDate { get; set; }
        public string? BillRunSeq { get; set; }
        public string? BillRunTime { get; set; }
        public string? BillType { get; set; }

        public Bill() { }

        // Returns string of date 5 days after current date
        public string getFirstNotificationDate()
        {
            return DateTime.Now.AddDays(5).ToString("MM/dd/yyyy");
        }

        // Returns string of date 3 days before the bill due date
        public string getSecondNotificationDate()
        {
            return DateTime.Parse(new DateCorrector(DueDate).CorrectedDate).AddDays(-3).ToString("MM/dd/yyyy");
        }

        public string getHHVALUE()
        {
            return HH_VALUE;
        }

        public string getIIVALUE()
        {
            return II_VALUE;
        }

        public string getJJVALUE()
        {
            return II_VALUE;
        }
    }

}