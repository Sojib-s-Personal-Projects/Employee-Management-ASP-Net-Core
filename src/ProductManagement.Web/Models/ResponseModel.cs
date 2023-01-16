using Infrastructure.Enum;

namespace ProductManagement.Web.Models
{
    public class ResponseModel
    {
        public string? Message { get; set; }
        public ResponseTypes Type { get; set; }
    }
}