using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string EmpName { get; set; } = null!;
}
