﻿using Eshoping.Registration.model.UserRegistartion;
using Microsoft.EntityFrameworkCore;
using System;

namespace Eshoping.Registration.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Test> test { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<PermentaAddress> PermentaAddress { get; set; }
        public DbSet<TemporaryAddress> TemporaryAddress { get; set; }
        public DbSet<DistrictDetais> DistrictDetais { get; set; }
        public DbSet<CityDetails> CityDetails { get; set; }
        public DbSet<Gender> Gender { get; set; }



    }
}
