using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
namespace FeedbackRegister.Data

{
    public class ConnectClass
    {
        public class ConnectContext : DbContext
        {
            public DbSet<Employee>? employees { get; set; }
            public DbSet<Role>? roles { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
            {
                var Username = "postgres";
                var Userpassword = "postgres";
                try
                {
                    optionsbuilder.UseNpgsql("Server=localhost;Port=5432;Username=" + Username + ";Password=" + Userpassword + ";Database=feedbackdb;");
                }
                catch (Exception exp) { string message = exp.Message; /*MessageBox.Show("Ошибка подключения: " + exp.Message, "Ошибка"); */}
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //base.OnModelCreating(modelBuilder);

                /*modelBuilder.Entity<Employee>()
                    .HasOne(x => x.role)
                    .WithMany(y=>y.employees)
                    .HasForeignKey(z=>z.roleid);*/
            }
        }
        
        public class Role
        {
            public Guid id { get; set; }
            public string? roleName { get; set; }
            public string? comment { get; set; }
        }
        public class Employee
        {
            public Guid id { get; set; }
            public string? name { get; set; }
            public string? email { get; set; }
            public string? telefon { get; set; }
            public bool deactivation { get; set; }
            public Guid roleid { get; set; }
        }
    }
}
