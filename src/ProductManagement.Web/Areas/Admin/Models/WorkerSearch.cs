namespace ProductManagement.Web.Areas.Admin.Models
{
    public class WorkerSearch
    {
        public long Roll {  get; set; }
        public string User { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PermanentAddress { get; set; }
        public string Quota { get; set; }
        public long BarCodeData { get; set; }
    }
}