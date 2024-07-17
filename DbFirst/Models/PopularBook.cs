using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class PopularBook
{
    public string? Title { get; set; }

    public long? NbLoans { get; set; }
}
