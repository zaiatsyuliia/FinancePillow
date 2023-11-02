using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Expense
{
    public decimal ExpenseSum { get; set; }

    public int? UserId { get; set; }

    public int? CategoryId { get; set; }

    public int ExpenseId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User? User { get; set; }
}
