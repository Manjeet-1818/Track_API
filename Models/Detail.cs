using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace BuildAPI.Models;

public partial class Detail
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public string? Address { get; set; }
}
