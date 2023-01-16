using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Services
{
    public class TimeService : ITimeService
    {
        public DateTime Now
        {
            get => DateTime.UtcNow;
        }

        public DateTime LocalTime
        {
            get => Now.ToLocalTime();
        }
    }
}