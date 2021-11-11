using System;
using System.CommandLine;

namespace GoDaddy
{
    public class OptionDomain : Option<string>
    {
        public OptionDomain() : base("--domain", "GoDaddy domain.")
        {
            IsRequired = true;
        }
    }
}

