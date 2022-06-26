using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace Handicraft.Data

{
    public class ConnectDB
    {
        public class ConnectContext : DbContext
        {
            static public string? Login { get; set; }
            static public string? Password { get; set; }
            public DbSet<User>? users { get; set; }
            public DbSet<Type>? types { get; set; }
            public DbSet<Requisite>? requisites { get; set; }
            public DbSet<Product>? products { get; set; }
            public DbSet<Favourites>? favourites { get; set; }
            public DbSet<Contacts>? contacts { get; set; }
            public DbSet<Cart>? carts { get; set; }
            public DbSet<Add_favourite>? add_favourites { get; set; }
            public DbSet<Add_cart>? add_carts { get; set; }
            

            public ConnectContext(string login, string password)
            {
                //Login = login; Password = password;
                Login = "postgres";
                Password = "postgres";

            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
            {
                try
                {
                    optionsbuilder.UseNpgsql("Server=localhost;Port=5432;Username=" + Login + ";Password=" + Password + ";Database=handicraft;");
                }
                catch (Exception exp) { string message = exp.Message; /*MessageBox.Show("Ошибка подключения: " + exp.Message, "Ошибка");*/ }
            }
        }
        public class User
        {
            public Guid id { get; set; }
            public string? name { get; set; }
            public string? login { get; set; }
            public string? email { get; set; }
            public string? telefon { get; set; }
            public DateTime? date { get; set; }
            public string? contacts { get; set; }
            public string? comment { get; set; }
            public string? password { get; set; }
        }
        public class Type
        {
            public Guid id { get; set; }
            public string? name { get; set; }
        }
        public class Requisite
        {
            public Guid id { get; set; }
            public string? name { get; set; }
            public string? number { get; set; }
        }
        public class Product
        {
            public Guid id { get; set; }
            public string? name { get; set; }
            public string? material { get; set; }
            public string? color { get; set; }
            public int? price { get; set; }
            public bool? stock { get; set; }
            public string? comments { get; set; }
            public Type? type { get; set; }
        }
        public class Favourites
        {
            public Guid id { get; set; }
            public User? id_user { get; set; }
            public int? final_price { get; set; }
        }
        public class Section
        {
            public Guid id { get; set; }
            public string? name { get; set; }
            public string? comment { get; set; }
        }
        public class Contacts
        {
            public Guid id { get; set; }
            public string? name { get; set; }
            public string? link { get; set; }
        }
        public class Cart
        {
            public Guid id { get; set; }
            public User? id_user { get; set; }
            public int? final_price { get; set; }
        }
        public class Add_favourite
        {
            public Guid id { get; set; }
            public Product? id_products { get; set; }
            public User? id_user { get; set; }
            public Favourites? id_favourites { get; set; }
            public DateTime? date { get; set; }
        }
        public class Add_cart
        {
            public Guid id { get; set; }
            public Product? id_products { get; set; }
            public User? id_user { get; set; }
            public Favourites? id_cart { get; set; }
            public DateTime? date { get; set; }
        }
    }
}
