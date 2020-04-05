using Module1.Examples;

namespace Module1
{
    public static class DividePerZero
    {
        public static int Divide(int dividend, NonZeroInteger divider)
        {
            return dividend / divider.Value;    
        }

        public static int? Divide(int dividend, int divider)
        {
            if (divider == 0) return null;

            return dividend / divider;
        }
    }
}
