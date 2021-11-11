using System;
using System.CommandLine;

namespace GoDaddy;

public class OptionType : Option<RecordType>
{
    public OptionType() : base("--type", "Record type.")
    {
        IsRequired = true;
    }
}


