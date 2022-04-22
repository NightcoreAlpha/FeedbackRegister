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
        public List<Employee> employee = new List<Employee>();
        Employee employeeOne = new Employee();
        public List<Employee> getEmployee(Guid id)
        {
            using(var db = new ConnectContext())
            {
                employee = db.employees?.Where(x => x.id == id).ToList();
            }
            return employee;
        }
    }
}
