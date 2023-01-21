namespace Infrastructure.Exceptions
{
    public class PriceNullOrStringException : Exception
    {
        public PriceNullOrStringException(string message)
            : base(message)
        { }
    }
}