
using System.Text;
using Newtonsoft.Json;
using System.CommandLine;
using GoDaddyApi.Console;
using GoDaddy;
using System.CommandLine.Invocation;
using System.Configuration;

namespace GoDaddy;

public class Program
{
    static async Task Main(string[] args)
    {   
        var api = new Api(ConfigurationManager.AppSettings.Get("key"),
            ConfigurationManager.AppSettings["secret"]);
        var rootCommand = new RootCommand();
        rootCommand.AddCommand(new Record(api));
        await rootCommand.InvokeAsync(args);
    }
}
