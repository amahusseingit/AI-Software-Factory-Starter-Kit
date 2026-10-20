namespace Factory.Api.Configuration;

public sealed class AIOptions
{
    public bool Enabled { get; set; }
    public string? Endpoint { get; set; }
    public string[] AllowedEndpoints { get; set; } = [];
    public string? Model { get; set; }
    public string? ApiKey { get; set; }
}
