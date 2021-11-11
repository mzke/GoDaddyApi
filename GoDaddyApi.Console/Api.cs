using System;
namespace GoDaddy;

public class Api : HttpClient
{
    public Api(string? key, string? secret) : base() 
    {
        DefaultRequestHeaders.Add("Authorization", $"sso-key {key}:{secret}");
    }
}


