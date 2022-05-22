using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FeedbackRegister.Data.ConnectClass;
//using static FeedbackRegister.Data.ConnectClass;
namespace FeedbackRegister.Data
{
    public class GetDataClass
    {
        public List<Employee>? employee = new List<Employee>();
        public List<Role>? role = new List<Role>();
        public List<Customer>? customers = new List<Customer>();
        public List<Section>? sectionList = new List<Section>();
        public List<Status>? statusList = new List<Status>();
        public List<Priority>? priorityList = new List<Priority>();
        public List<Employee>? owner_gkiList = new List<Employee>();
        public List<Employee> getEmployee(Guid id)
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
        }
    }
}
