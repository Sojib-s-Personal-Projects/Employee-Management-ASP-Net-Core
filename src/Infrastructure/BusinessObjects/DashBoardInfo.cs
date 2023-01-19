using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BusinessObjects
{
    public class DashBoardInfo
    {
        public long Roll { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PermanentDistrict { get; set; }
        public string Quota { get; set; }
        public string BarCodeData { get; set; }
        public double? Price { get; set; }
    }
}
