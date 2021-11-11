using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using GoDaddy;
using System.Text;
using Newtonsoft.Json;

namespace GoDaddyApi.Console;

public class Record : Command
{
    Api Api;
    public Record(Api api) : base("record", "GoDaddy DNS record command.")
    {
        Api = api;
        var domain = new OptionDomain();
        AddOption(domain);

        var type = new OptionType();
        AddOption(type);

        var name = new OptionName();
        AddOption(name);

        var data = new OptionData();
        AddOption(data);

        Handler = CommandHandler.Create< string, RecordType, string, string>( HandleCommand);
    }

    private  void  HandleCommand( string domain, RecordType type, string name, string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            var httpClient = new HttpClient();
            try
            {
                Task<string> ip =  httpClient.GetStringAsync("https://api.ipify.org");
                data = ip.Result;
                
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        var array = new List<GoDaddyApi.Model.DNSRecordCreateTypeName>();
        var dnsRecord = new GoDaddyApi.Model.DNSRecordCreateTypeName
        {
            data = data,
            ttl = 600,
            port = 65535,
            priority = 0,
            weight = 0,
            protocol = String.Empty,
            service = String.Empty
        };
        array.Add(dnsRecord);
        var json = JsonConvert.SerializeObject(array);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var url = $"https://api.godaddy.com/v1/domains/{domain}/records/{type}/{name}";
        Task<HttpResponseMessage> response = Api.PutAsync(url, content);
        var result = response.Result;// Content.ReadAsStringAsync().Result;
        System.Console.WriteLine($"{DateTime.Now} {result.StatusCode} {result.ReasonPhrase}");
    }
}
