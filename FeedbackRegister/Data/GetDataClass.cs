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
    }
}
