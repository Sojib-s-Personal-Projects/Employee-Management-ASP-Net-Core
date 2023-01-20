namespace Infrastructure.Exceptions
{
    public class WorkerExistsException : Exception
    {
        public WorkerExistsException(string message)
            : base(message)
        { }
    }
}