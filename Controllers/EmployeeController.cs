using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SamplePostgre.Data;

namespace SamplePostgre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        

        private readonly ILogger<EmployeeController> _logger;
        private ApplicationDbContext _context;

        public EmployeeController(ILogger<EmployeeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            if(_context.Employees.Count() ==0)
            {
                var employeeList = new List<Employee>
                {
                    new Employee{Id=1,FirstName="Sample1",LastName="User1",DateOfBirth=new DateTime(1990,10,10)},
                    new Employee{Id=2,FirstName="Sample2",LastName="User2",DateOfBirth=new DateTime(1980,5,6)},
                    new Employee{Id=3,FirstName="Sample3",LastName="User3",DateOfBirth=new DateTime(1987,4,3)},
                };
                _context.Employees.AddRange(employeeList.ToArray());
                _context.SaveChanges();
            }
            return _context.Employees.ToList();
        }
    }
}
