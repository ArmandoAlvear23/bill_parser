public partial class Program
{
    public class Address
    {
        public string MailingAddress1 { get; private set; }
        public string MailingAddress2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Zip { get; private set; }
        public AddressType Type { get; private set; }

        public Address(string mailingAddress1, string mailingAddress2,
            string city, string state, string zip, AddressType type = AddressType.Home)
        {
            MailingAddress1 = mailingAddress1.ToUpper();
            MailingAddress2 = mailingAddress2.ToUpper();
            City = city.ToUpper();
            State = state.ToUpper();
            Zip = zip;
            Type = type;
        }

        // Combines address properties
        public string GetFullAddress()
        {
            return $"{MailingAddress1}, {MailingAddress2} {City}, {State} {Zip}";
        }
    }

}