using System;
using System.CommandLine;

namespace GoDaddy;

public class OptionName : Option<string>
{
    public OptionName() : base("--name", "Record name.")
    {
        IsRequired = true;
    }
}


