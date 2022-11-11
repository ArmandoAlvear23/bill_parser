public partial class Program
{
    public class Customer : Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get; }

        public List<Address> adresses = new List<Address>();

        public Customer() { }

        public Customer(string fullName)
        {
            FullName = fullName.ToUpper();
            SeparateNames();
        }

        // Separates the first and last name values into their own
        // properties
        public void SeparateNames()
        {
            FirstName = FullName.Substring(FullName.LastIndexOf(" ") + 1);
            LastName = FullName.Substring(0, FullName.IndexOf(","));
        }
    }

}