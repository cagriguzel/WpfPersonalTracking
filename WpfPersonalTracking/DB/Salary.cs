﻿using System;
using System.Collections.Generic;

namespace WpfPersonalTracking.DB;

public partial class Salary
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? Amount { get; set; }

    public int? Year { get; set; }

    public int? Month { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Month? MonthNavigation { get; set; }
}
