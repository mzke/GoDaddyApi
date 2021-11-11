using System;
using System.CommandLine;

namespace GoDaddy;

public class OptionData : Option<string>
{
    public OptionData() : base("--data", "Record data.")
    {
        IsRequired = false;
    }
}


