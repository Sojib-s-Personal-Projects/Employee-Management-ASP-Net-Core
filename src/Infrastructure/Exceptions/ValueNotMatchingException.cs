namespace Infrastructure.Exceptions
{
    public class ValueNotMatchingException : Exception
    {
        public ValueNotMatchingException(string message)
            : base(message)
        { }
    }
}
