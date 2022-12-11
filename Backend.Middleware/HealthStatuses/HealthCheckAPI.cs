namespace Backend.Middleware.HealthStatuses;

public class HealthCheckAPI : IHealthCheck
{
    private HttpClient _client { get; }

    public HealthCheckAPI(HttpClient client)
    {
        _client = client;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await _client.SendAsync(new HttpRequestMessage(HttpMethod.Head, _client.BaseAddress));
            response.EnsureSuccessStatusCode();

            return HealthCheckResult.Healthy();
        }
        catch
        {
            return HealthCheckResult.Unhealthy();
        }
    }
}
