using CSharpFunctionalExtensions;
using System;
namespace CustomerManagement.Logic.Model
{
    public class Email : Common.ValueObject<Email>
    {
        public string Value { get; }
        private Email(string value)
        {
            Value = value;
        }

         public static Result<Email> Create(Maybe<string> emailOrNothing)
        {
            return emailOrNothing.ToResult("Email should not be empty")
                .OnSuccess(email => email.Trim())
                .Ensure(email => email != string.Empty, "Email not be empty") 
                .Ensure(email => email.Length <= 220, "Email not be less than 220")
                .Map(email => new Email(email));    
        }

        protected override bool EqualsCore(Email other)
        {
            throw new NotImplementedException();
            //return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
            //return Value.GetHashCode();
        }

        public static explicit operator Email(string email)
        {
            return Create(email).Value;
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }

    }
}
