using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.Services
{
    public interface ITimeService
    {
        DateTime Now { get; }
        DateTime LocalTime { get; }
    }
}