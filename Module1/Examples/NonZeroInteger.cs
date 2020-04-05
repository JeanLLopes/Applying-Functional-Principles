using System;

namespace Module1.Examples
{
    public class NonZeroInteger
    {
        public NonZeroInteger(int value)
        {
            if (value == 0) throw new DivideByZeroException("Divisor not can acceptance zero ou negative numbers");
            Value = value;
        }

        public int Value { get; set; }

    }
}
