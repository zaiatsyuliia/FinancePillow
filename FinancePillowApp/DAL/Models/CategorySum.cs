﻿using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class CategorySum
{
    public int? UserId { get; set; }

    public int? CategoryId { get; set; }

    public decimal TotalExpense { get; set; }
}
