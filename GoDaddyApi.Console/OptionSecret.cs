using System;
using System.CommandLine;

namespace GoDaddy
{
    public class OptionSecret : Option<string>
    {
        public OptionSecret() : base("--secret", "GoDaddy production secret.")
        {
            IsRequired = true;
        }
    }
}

