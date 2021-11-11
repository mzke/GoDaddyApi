
namespace GoDaddyApi.Model;

public record DNSRecordCreateTypeName
{
    public string data { get; set; }
    public ushort port { get; set; }     // Service port (SRV only)
    public ushort priority { get; set; } // Record priority(MX and SRV only)
    public string? protocol { get; set; } // Service protocol (SRV only)
    public string? service { get; set; }  // Service type (SRV only)
    public ushort ttl { get; set; }
    public ushort weight { get; set; }   // Record weight (SRV only)

}


