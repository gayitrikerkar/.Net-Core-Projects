using System;
using System.Collections.Generic;

namespace DbFirstCrudApp.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string EmpName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public int? Age { get; set; }
}
