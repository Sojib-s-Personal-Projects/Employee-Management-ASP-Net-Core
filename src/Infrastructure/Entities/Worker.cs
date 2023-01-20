namespace Infrastructure.Entities
{
    public class Worker : IEntity<long>
    {
        public long Id { get; set; }
        public string PostName { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PermanentDistrict { get; set; }
        public string Quota { get; set; }
        public WorkerInfo WorkerInfo { get; set; }
    }
}