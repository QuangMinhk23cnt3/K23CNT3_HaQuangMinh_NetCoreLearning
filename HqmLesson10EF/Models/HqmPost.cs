using System;
using System.Collections.Generic;

namespace HqmLesson10EF.Models;

public partial class HqmPost
{
    public int HqmId { get; set; }

    public string? HqmTitle { get; set; }

    public string? HqmImage { get; set; }

    public string? HqmContent { get; set; }

    public bool? HqmStatus { get; set; }
}
