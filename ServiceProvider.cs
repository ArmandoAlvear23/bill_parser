public partial class Program
{
    public class ServiceProvider
    {
        public string Name { get; }
        public Address address { get; }

        public ServiceProvider()
        {
            Name = "Invoice Cloud, Inc.";
            address = new Address("30 Braintree Hill Office Park", "Suite 303", "Braintree", "MA", "02184", AddressType.Business);
        }
    }

}