using System;
using System.CommandLine;

namespace GoDaddy;

    public class OptionKey : Option<string>
    {
        public OptionKey():base("--key", "GoDaddy production key.")
        {
            IsRequired = true;
        }
    }


