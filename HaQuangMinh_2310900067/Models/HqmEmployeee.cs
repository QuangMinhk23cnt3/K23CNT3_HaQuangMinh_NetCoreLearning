using System;
using System.Collections.Generic;

namespace HaQuangMinh_2310900067.Models;

public partial class HqmEmployeee
{
    public int HqmEmpId { get; set; }

    public string? HqmEmpName { get; set; }

    public string? HqmEmpLevel { get; set; }

    public DateOnly? HqmEmpStartDate { get; set; }

    public bool? HqmEmpStatus { get; set; }
}
