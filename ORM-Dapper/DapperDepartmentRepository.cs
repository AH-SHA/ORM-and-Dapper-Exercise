using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        
        //Constructor
        public DapperDepartmentRepository(IDbConnection connection) 
        {
            _connection = connection;
        }


        // the method below returns each row in the department table as a collection/IEnumberable within C#
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM departments");
        }

        
        // Add a method to insert a department. It returns nothing.
        //In VS if the paramter name is same as the variable name, then Visual studio can infer the name if you type it once
        //Call the methods inside the main function
        public void InsertDepartment(string name)
        {
            _connection.Execute("INSERT INTO departments (Name) VALUES (@name)",
                new {name = name });
        }





    }
}
