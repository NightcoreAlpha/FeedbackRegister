using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Handicraft.Data.ConnectDB;
//using static Handicraft.Data.ConnectClass;
namespace Handicraft.Data
{
    public class GetDataClass
    {
        public static List<User> userData { get; set; }
        public static List<ConnectDB.Type> getTypes()
        {
            List<ConnectDB.Type>? types = new List<ConnectDB.Type>();
            try
            {
                using (var db = new ConnectContext("postgres", "postgres"))
                {
                    types = db.types?.ToList();
                }
            }
            catch (Exception ex) { }
            return types;
        }
        public static List<Product> getProducts()
        {
            List<Product>? products = new List<Product>();
            using (var db = new ConnectContext("postgres", "postgres"))
            {
                products = db.products?.ToList();
            }
            return products;
        }
        public static List<Product> getProductsType(ConnectDB.Type idType)
        {
            List<Product>? products = new List<Product>();
            using (var db = new ConnectContext("postgres", "postgres"))
            {
                products = db.products?.Where(x => x.type == idType).ToList();
                //products = db.products?.ToList();
            }
            return products;
        }
        public static List<Product> getProduct(Guid idProduct)
        {
            List<Product>? products = new List<Product>();
            using (var db = new ConnectContext("postgres", "postgres"))
            {
                products = db.products?.Where(x => x.id == idProduct).Include(x => x.type).ToList();
                //products = db.products?.ToList();
            }
            return products;
        }
        public List<Claim> GetUser(string login, string password)
        {
            List<Claim>? claimsList = new List<Claim>();
            /*using (var db = new ConnectContext())
            {
                //users = db.users?.Where(x => x.login == idType).ToList();
                //products = db.products?.ToList();
            }*/
            return claimsList;
        }

        public static List<User> GetUserData(string login)
        {
            List<User> user = new List<User>();
            try
            {
                using (var db = new ConnectContext("", ""))
                {
                    user = db?.users?.Where(x => x.login == login).ToList();
                    var mess = "";
                }
            }
            catch (Exception ex) { }
            return user;
        }
        public static List<User> GetUserData(string login, string password)
        {
            List<User> user = new List<User>();
            try
            {
                using (var db = new ConnectContext("", ""))
                {
                    user = db?.users?.Where(x => x.login == login && x.password == password).ToList();
                    var mess = "";
                }
            }
            catch (Exception ex) { }
            return user;
        }
        public static List<User> GetUserData(Guid id)
        {
            List<User> user = new List<User>();
            try
            {
                using (var db = new ConnectContext("", ""))
                {
                    user = db?.users?.Where(x => x.id == id).ToList();
                    var mess = "";
                }
            }
            catch (Exception ex) { }
            return user;
        }
        //public static List<ConnectDB.Type> GetType()
        //{
        //    List<ConnectDB.Type> types = new List<ConnectDB.Type>();
        //    using (var db = new ConnectContext("", ""))
        //    {
        //        types = db?.types?.ToList();
        //        var mess = "";
        //    }
        //    return types;
        //}
    }
}
