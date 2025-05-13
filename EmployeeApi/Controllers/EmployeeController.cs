using EmployeeApi.Context;
using EmployeeApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [Route("getEmployee")]
        public List<Employee> GetEmployees()
        {
            using (EmployeeContext context = new EmployeeContext())
            {
                return context.Employees.ToList();
            }
        }

        [HttpPost]
        [Route("createEmployee")]
        public string CreateEmployee(Employee employee)
        {
            using EmployeeContext context = new EmployeeContext();
            context.Employees.Add(employee);
            context.SaveChanges();
            return $"{JsonConvert.SerializeObject(employee)}員工資訊已加入清單";
        }

        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public ActionResult UpdateEmployee(string id, [FromBody] Employee employee)
        {
            using EmployeeContext context = new EmployeeContext();
            Employee? originalEmployee = context.Employees.FirstOrDefault(x => x.Id.Equals(id));
            if (originalEmployee == null)
                return BadRequest("ID not found");
            if (employee.Id != id)
                return BadRequest("不可修改 ID");

            originalEmployee.Name = employee.Name;
            originalEmployee.Grade = employee.Grade;
            context.SaveChanges();
            return Ok($"{JsonConvert.SerializeObject(originalEmployee)}員工資訊已被修改");
        }

        [HttpDelete]
        [Route("deleteEmployee/{id}")]
        public ActionResult DeleteEmployee(string id)
        {
            using EmployeeContext context = new EmployeeContext();
            Employee? originalEmployee = context.Employees.FirstOrDefault(x => x.Id.Equals(id));
            if (originalEmployee == null)
                return BadRequest("ID not found");

            context.Employees.Remove(originalEmployee);
            context.SaveChanges();
            return Ok($"{JsonConvert.SerializeObject(originalEmployee)}員工資訊已被刪除");
        }
    }
}
