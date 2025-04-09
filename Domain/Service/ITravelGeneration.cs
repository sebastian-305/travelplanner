using travelplanner.Domain.Models;

namespace travelplanner.Domain.Service;

public interface ITravelGeneration
{
    public Task<string?> GenerateLandmarks(string cityName);

    public Task<string?> GernerateTravelReport(IEnumerable<TravelTargets> targets); 
}
