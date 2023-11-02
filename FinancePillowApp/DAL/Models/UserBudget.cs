using System;
using System.Collections.Generic;

namespace Models;

public partial class UserBudget
{
    public int? UserId { get; set; }

    public decimal? TotalExpenses { get; set; }

    public decimal? TotalIncomes { get; set; }

    public decimal? Budget { get; set; }
}
