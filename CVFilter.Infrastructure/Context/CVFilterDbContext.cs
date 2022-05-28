﻿using CVFilter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Context
{
    public class CVFilterDbContext : DbContext
    {
        public CVFilterDbContext(DbContextOptions<CVFilterDbContext> options) : base(options)
        {

        }

        public DbSet<Applicant> Applicants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
