using System;
using System.Collections.Generic;
using System.Text;

namespace Module4
{
    public sealed class Customer : Result
    {
        public Customer(string name, int age)
        {
            Name = name;
            Age = age;

            ValidateName();
            ValidateAge();
        }

        private void ValidateAge()
        {
            if (Age < 18)
            {
                AddErrorMessage("Customer is under age");
                return;
            }
        }

        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                //WRONG
                //throw new ArgumentNullException("Name is null or empty");
                
                //CORRECT
                AddErrorMessage("Name is null");
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                AddErrorMessage("Name is null or empty");
                return;
            }
        }

        public String Name { get; }
        public int Age { get; }

    }
}
