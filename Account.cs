public partial class Program
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string AccountClass { get; set; }
        public string AccountBalance { get; set; }
        public Customer customer { get; set; }
        public List<Bill> bills = new List<Bill>();

        public Account() { }
    }

}