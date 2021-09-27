using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_API_TEST.Repository;
using MVC_API_TEST.Interfaces;
using MVC_API_TEST.Models;

namespace MVC_API_TEST.Controllers
{
    public class EmployeeController : ApiController
    {
        IEmployeeRepository _objNewEmpRepository;

        private  EmployeeController()
        {
            _objNewEmpRepository = new EmployeeRepository();
        }
        // GET: api/Employee
        [Route ("Employees")]
        [HttpGet]
        public List<EmployeeModel> GetDefaultEmp()
        {
            return _objNewEmpRepository.GetAllEmployees(10, "EmpName");
        }

        [Route("Employees/{EmpID}")]
        [HttpGet]
        public EmployeeModel GetDefaultEmp(int EmpID)
        {
            return _objNewEmpRepository.GetSingleEmployee(EmpID);
        }
        
        [Route("Employees/{topCount}/{colName}")]
        [HttpGet]
        public List<EmployeeModel> GetAllEmp(int topCount, string colName)
        {
            return _objNewEmpRepository.GetAllEmployees(topCount, colName);
        }

        //Get Emp by ID
      

        //[Route("Employees/{EmpId}")]
        //[HttpGet]
        //public EmployeeModel GetSingleEmp(int intEmpid)
        //{
        //    return _objNewEmpRepository.GetSingleEmployee(intEmpid);
        //}

       [Route("Employees")]
       [HttpPost]
       public bool InsertEmployee([FromBody]EmployeeModel empRecord)
        {
            return _objNewEmpRepository.InsertEmployee(empRecord);
        }

        // PUT: api/Customer/5
        [Route("Employees")]
        [HttpPut]
        public bool UpdateEmployee([FromBody] EmployeeModel empRecord)
        {
            return _objNewEmpRepository.UpdateEmployee(empRecord);
        }

        //DELETE: api/Employee/5
        [Route("Employees/{EmpID}")]
        [HttpDelete]
        public bool DeleteEmployee(int EmpID)
        {
            return _objNewEmpRepository.DeleteEmployee(EmpID);
        }
    }
}
