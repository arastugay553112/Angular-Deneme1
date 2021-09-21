﻿using API.Core.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.infrastructure.DataContext
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
    }
}
