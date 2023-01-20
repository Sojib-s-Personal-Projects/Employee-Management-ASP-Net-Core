namespace Infrastructure.Exceptions
{
    public class PriceNotEnteredException : Exception
    {
        public PriceNotEnteredException(string message)
            : base(message)
        { }
    }
}