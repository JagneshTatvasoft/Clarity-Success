using System;
using System.Collections.Generic;
using ClarityAndSuccess.Domain.Entities;
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
    public virtual DbSet<Branch> Branches { get; set; }
    public virtual DbSet<BranchCustomerNumber> BranchCustomerNumbers { get; set; }
    public virtual DbSet<MasterData> MasterDatas { get; set; }
    public virtual DbSet<CustomerContactPerson> CustomerContactPersons { get; set; }
   
}
