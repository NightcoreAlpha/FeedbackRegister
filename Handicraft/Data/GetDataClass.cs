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
            using (var db = new ConnectContext("postgres", "postgres"))
            {
                types = db.types?.ToList();
            }
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

        public static List<User> GetUserData(string login, string password)
        {
            List<User> user = new List<User>();
            using (var db = new ConnectContext("",""))
            {
                user = db?.users?.Where(x => x.login == login && x.password == password).ToList();
                var mess = "";
            }
            return user;
        }

        /*public List<Employee>? employee = new List<Employee>();
        public List<Role>? role = new List<Role>();
        public List<Customer>? customers = new List<Customer>();
        public List<Section>? sectionList = new List<Section>();
        public List<Status>? statusList = new List<Status>();
        public List<Priority>? priorityList = new List<Priority>();
        public List<Employee>? owner_gkiList = new List<Employee>();*/
        /*public List<Employee> getEmployee(Guid id)
        {
            using(var db = new ConnectContext())
            {
                employee = db.employees?.Where(x => x.id == id).ToList();
            }
            return employee;
        }
        public List<Role> getRoleList()
        {
            using (var db = new ConnectContext())
            {
                role = db.roles?.ToList();
            }
            return role;
        }
        public List<Customer> getCustomerList()
        {
            using (var db = new ConnectContext())
            {
                customers = db.customers?.Include(x=>x.company).ToList();
            }
            return customers;
        }
        public List<Section> getSectionsList()
        {
            using (var db = new ConnectContext())
            {
                sectionList = db.sections.ToList();
            }
            return sectionList;
        }
        public List<Status> getStatusList()
        {
            using (var db = new ConnectContext())
            {
                statusList = db.status.ToList();
            }
            return statusList;
        }
        public List<Priority> getPriorityList()
        {
            using (var db = new ConnectContext())
            {
                priorityList = db.priority.ToList();
            }
            return priorityList;
        }
        public List<Employee> getOwner_gkiList()
        {
            using (var db = new ConnectContext())
            {
                owner_gkiList = db.employees.ToList();
            }
            return owner_gkiList;
        }*/
    }
}
