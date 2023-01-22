namespace Infrastructure.BusinessObjects
{
    public class WorkerInfo
    {
        public Guid Id { get; set; }
        public string BarCodeData { get; set; }
        public Worker Worker { get; set; }
        public long Roll { get; set; }
        public double? Price { get; set; }
        public bool PriceConfirmed { get; set; }
    }
}