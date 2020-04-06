using System;

namespace Module2.Examples
{
    public class ImutabilityCustomer
    {
        public void ProcessCreateCustomer(string customerName, string addressName)
        {
            try
            {
                Address address = CreateAddress(addressName);
                Customer customer = CreateCustomer(customerName, address);
                SaveCustomer(customer);

            }
            catch (Exception)
            {
                throw new ApplicationException();
            }        
        }

        private void SaveCustomer(Customer customer)
        {
            //SAVE CSUTOMER IN REPOSITORY
        }

        private Customer CreateCustomer(string customerName, Address address)
        {
            return new Customer(customerName, address);
        }

        private Address CreateAddress(string addressName)
        {
            return new Address(addressName);
        }
    }
}
