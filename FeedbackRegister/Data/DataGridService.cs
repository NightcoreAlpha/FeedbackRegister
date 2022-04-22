using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FeedbackRegister.Data.ConnectClass;
namespace FeedbackRegister.Data
{
    public class DataGridService
    {
        List<CounterEmployee> employee = new List<CounterEmployee>();
        List<CounterEmployee> getEmployees(List<CounterEmployee> employee)
        {
            employee.Clear();
            using (var db = new ConnectContext())
            {
                var employ = from emp in db.employees
                             join rol in db.roles on emp.roleid equals rol.id
                             select new
                             {
                                 emp.id,
                                 emp.name,
                                 emp.email,
                                 emp.telefon,
                                 emp.deactivation,
                                 rol.roleName
                             };
                //for (int i = 0; i < 500; i++)
                //{
                    foreach (var c in employ)
                    {
                        employee.Add(new CounterEmployee()
                        {
                            id = c.id,
                            name = c.name,
                            email = c.email,
                            telefon = c.telefon,
                            deactivation = c.deactivation,
                            roleName = c.roleName
                        });
                    }
                //}
            }
            return employee;
        }
        //List<Employee>? employees { get; set; }

        /*List<Employee> getEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using(var db = new ConnectContext())
            {
                var employee = from emp in db.employees
                               join rol in db.roles on emp.roleId equals rol.id
                               select new
                               {
                                   emp.id,
                                   emp.name,
                                   emp.email,
                                   emp.deactivation,
                                   nameRole = rol.name
                               };
            return (List<Employee>)employee;
            }
        }*/
        /*{
             new Employee{id = new Guid("5a48c7aa-bcfe-11ec-9d64-0242ac120002"), name = "Ситников Виктор", email= "v.sitnikov@dt-pro.net",deactivation = false, roleId = new Guid("38b415e0-bcfe-11ec-9d64-0242ac120002") }
        };*/
        /*public async Task<List<CounterEmployee>> EmployeeList()
        {
            getEmployees();
            return await Task.FromResult(employee);
        }*/
        public List<CounterEmployee> EmployeeList()
        {
            return getEmployees(employee);
        }
        public class CounterEmployee
        {
            public Guid id { get; set; }
            public string? name { get; set; }
            public string? email { get; set; }
            public string? telefon { get; set; }
            public bool deactivation { get; set; }
            public string? roleName { get; set; }
        }
    }
}
