using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_API_TEST.Interfaces;
using MVC_API_TEST.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;



namespace MVC_API_TEST.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _dbCon;

        public EmployeeRepository()
        {
            _dbCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public List<EmployeeModel> GetAllEmployees(int intTopCount, string strSortColName)
        {
            try
            {
                return this._dbCon.Query<EmployeeModel>("Select top " + intTopCount + " * from Employees order by " + strSortColName + "").ToList(); ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public EmployeeModel GetSingleEmployee(int intEmpID)
        {
            return this._dbCon.Query<EmployeeModel>("Select  * from Employees where empID =" + intEmpID + "").SingleOrDefault(); ;
        }

        public bool InsertEmployee(EmployeeModel objEmp)
        {
            try
            {
                int rowsAffected = this._dbCon.Execute(@"INSERT Employees(EmpName,EmpAddress,Gender,CompanyName,Designation) values (@EmpName,@EmpAddress,@Gender,@CompanyName,@Designation)",
                new { EmpName = objEmp.EmpName, EmpAddress = objEmp.EmpAddress, Gender = objEmp.Gender, CompanyName = objEmp.CompanyName, Designation = objEmp.Designation });

                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                
            }
            return false;
        }

        public bool UpdateEmployee(EmployeeModel objEmp)
        {
            bool result;
            try
            {
                
                int rowsAffected = this._dbCon.Execute(@"UPDATE Employees SET EmpName=@EmpName,EmpAddress=@EmpAddress,Gender=@Gender,CompanyName=@CompanyName,Designation=@Designation where EmpID=" + objEmp.EmpID, objEmp);

                if (rowsAffected > 0)
                {
                    result= true;
                }
                else
                {
                    result=false;
                }
            }
            catch
            {
                result=false;
            }
            return result;
        }


        public bool DeleteEmployee(int intEmpID)
        {
            int rowsAffected = this._dbCon.Execute(@"Delete from Employees where EmpID='" + intEmpID + "'");

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
