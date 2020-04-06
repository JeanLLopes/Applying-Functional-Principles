namespace Module2.Examples
{
    internal class Customer
    {
        public Customer(string name, Address address)
        {
            Name = name;
            this.address = address;
        }

        public string Name { get; private set; }
        public Address address { get; private set; }
    }
}