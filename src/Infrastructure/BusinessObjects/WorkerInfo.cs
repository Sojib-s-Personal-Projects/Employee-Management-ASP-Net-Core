using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BusinessObjects
{
    public class WorkerInfo
    {
        public Guid Id { get; set; }
        public string BarCodeData { get; set; }
        public Worker Worker { get; set; }
        public long Roll { get; set; }
        public double? Price { get; set; }
    }
}
