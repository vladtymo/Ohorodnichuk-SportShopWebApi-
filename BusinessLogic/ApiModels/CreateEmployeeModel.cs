using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiModels
{
    public class CreateEmployeeModel
    {
        public string Fullname { get; set; }
        public DateTime HireDate { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }
    }
}
