using Optiek_Declercq.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Model.Models
{
    public class Invoice
    {
        [Key]
        public int ID { get; set; }
        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
