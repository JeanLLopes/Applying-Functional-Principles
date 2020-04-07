using System;
using System.Collections.Generic;
using System.Text;

namespace Module4
{
    public class Result
    {
        public string ErrorMessage { get; private set; }
        public bool IsValid { get; private set; } = true;

        public void AddErrorMessage(string message)
        {
            ErrorMessage = message;
            IsValid = false;
        }
    }
}
