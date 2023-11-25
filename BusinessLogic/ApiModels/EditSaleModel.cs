using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiModels
{
    public class EditSaleModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
