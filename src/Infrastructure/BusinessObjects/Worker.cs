using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BusinessObjects
{
    public class Worker
    {
        public Guid Id { get; set; }
        public string PostName { get; set; }
        public long Roll { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PermanentDistrict { get; set; }
        public string Quota { get; set; }
    }
}
