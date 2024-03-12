using CerpApi.DatabaseEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CerpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CERPsHostedContext _context;

        public EmployeeController(CERPsHostedContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public IEnumerable<VAllEmployee> GetEmployees()
        {
            return _context.VAllEmployees;
        }

        // GET: api/Employee/10067
        [HttpGet("{id}")]
        public VAllEmployee GetEmployee([FromRoute] int id)
        {
            return _context.VAllEmployees.FromSqlRaw($"sp_employee_details {id} ").AsEnumerable().FirstOrDefault();
        }
    }
}
