using System;
using System.Collections.Generic;

namespace Models;

public partial class Income
{
    public decimal IncomeSum { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
