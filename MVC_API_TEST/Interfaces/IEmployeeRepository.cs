using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_API_TEST.Models;

namespace MVC_API_TEST.Interfaces
{
    interface IEmployeeRepository
    {
        List<EmployeeModel> GetAllEmployees(int intTopCount, string strSortColName);
        EmployeeModel GetSingleEmployee(int intEmpID);
        bool InsertEmployee(EmployeeModel objEmployee);
        bool UpdateEmployee(EmployeeModel objEmployee);
        bool DeleteEmployee(int intEmpID);


    }
}
