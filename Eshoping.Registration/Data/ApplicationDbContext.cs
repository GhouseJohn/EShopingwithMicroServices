using Eshoping.Registration.model.UserRegistartion;
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
    }
}
