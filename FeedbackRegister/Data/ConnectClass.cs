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
            public DbSet<Comment>? comments { get; set; }
            public DbSet<Company>? companies { get; set; }
            public DbSet<Status>? status { get; set; }
            public DbSet<Priority>? priority { get; set; }
            public DbSet<Section>? sections { get; set; }
            public DbSet<Customer>? customers { get; set; }
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
            public bool? deactivation { get; set; }
            //public  Guid? roleid { get; set; }
            public virtual Role? role { get; set; }
        }
        public class Company
        {
            public Guid id { get; set; }
            public string? name { get; set; }
            public string? city { get; set; }
            public string? comment { get; set; }

        }
        public class Status
        {
            public Guid id { get; set; }
            public string? name { get; set; }
        }
        public class Priority
        {
            public Guid id { get; set; }
            public string? name { get; set; }
        }
        public class Section
        {
            public Guid id { get; set; }
            public string? name { get; set; }
            public string? comment { get; set; }
        }
        public class Comment
        {
            public Guid id { get; set; }
            public string? name { get; set; }
            public string? data { get; set; }
            public DateTime? data_modified { get; set; }
            public string? comment { get; set; }
            public virtual Customer? author { get; set; }
            public virtual Employee? owner_gki { get; set; }
            public string? email_owner_gki { get; set; }
            public virtual Status? status { get; set; }
            public string? author_email { get; set; }
            public virtual Section? section { get; set; }
            public int? iteration { get; set; }
            public virtual Priority? priority { get; set; }
            public string? jira_task { get; set; }
            public string? data_comment_gki { get; set; }
            public string? comment_gki { get; set; }
            public string? confirmation_sl { get; set; }
            public string? comment_sl { get; set; }
        }
        public class Customer
        {
            public Guid id { get; set; }
            public string? name { get; set; }
            public string? email { get; set; }
            public string? comment { get; set; }
            public string? telefon { get; set; }
            public virtual Company? company { get; set; }
        }
    }
}
