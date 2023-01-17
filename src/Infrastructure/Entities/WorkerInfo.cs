using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class WorkerInfo : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string BarCodeData { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; } = null;
    }
}
