using System;
using System.Collections.Generic;
using ClarityAndSuccess.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ClarityAndSuccess.Domain.Data;

public partial class ClarityAndSuccessDBContext : DbContext
{
    public ClarityAndSuccessDBContext(DbContextOptions<ClarityAndSuccessDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
   
}
