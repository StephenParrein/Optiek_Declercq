using Optiek_Declercq.Model.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Optiek_Declercq.Model.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string StreetWithNumber { get; set; }
  
    }
}