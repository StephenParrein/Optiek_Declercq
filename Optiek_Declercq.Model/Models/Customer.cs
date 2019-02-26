using Optiek_Declercq.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Model.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public string EmailAdress { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public virtual Address GetAddress { get; set; }

        public int CompanyID { get; set; }


    }
}
