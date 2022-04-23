using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Day4
{
    public class EasyEmp
    {
        public string FN { get; set; }
        public string LN { get; set; }
    }
    public enum Department { IT, Finance, Facilities, HR}
    public class Employee
    {
        public int ID { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiringDate { get; set; }
        public decimal Salary { get; set; }
        public Department Department { get; set; }
        public bool IsManager { get; set; }
    }
}
