using System;
using System.Collections.Generic;

namespace DbfirstCrud.Models;

public partial class Student
{
    public int RollNo { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Gender { get; set; } = null!;

    public string Married { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Standard { get; set; } = null!;
}
