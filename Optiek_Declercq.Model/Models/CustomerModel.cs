using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Model.Models
{
    public class CustomerModel
    {
        [Key]
        public int ID { get; set; }

        public string EmailAdress { get; set; }
        public string HashedPassword { get; set; }

        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public virtual AddressModel Address { get; set; }

    }
}
