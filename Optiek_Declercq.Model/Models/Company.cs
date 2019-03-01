using Optiek_Declercq.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Model.Models
{
    public class Company
    {
        [Key]
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyVatNumber { get; set; }
        public bool CompanyProFormaBilling { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
    }
}
