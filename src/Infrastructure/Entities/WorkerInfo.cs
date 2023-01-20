namespace Infrastructure.Entities
{
    public class WorkerInfo : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string BarCodeData { get; set; }
        public Worker Worker { get; set; }
        public long Roll { get; set; }
        public double? Price { get; set; }
    }
}