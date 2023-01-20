namespace Infrastructure.Exceptions
{
    public class BarCodeExistsException : Exception
    {
        public BarCodeExistsException(string message)
            : base(message)
        { }
    }
}