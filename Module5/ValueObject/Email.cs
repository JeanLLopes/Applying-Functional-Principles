using Module5.Base;
using System;

namespace Module5.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public string Value { get; private set; }

        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new NullReferenceException("Email is nullable or empty");

            if (string.IsNullOrWhiteSpace(email))
                throw new NullReferenceException("Email is nullable or contains white spaces");

            return new Email(email);
        }

        protected override bool EqualsCore(Email other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
