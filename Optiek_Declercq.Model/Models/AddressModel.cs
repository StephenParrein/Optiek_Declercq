using System.ComponentModel.DataAnnotations;

namespace Optiek_Declercq.Model.Models
{
    public class AddressModel
    {
        [Key]
        public int ID { get; set; }

        public string City { get; set; }
        public string PostCode { get; set; }
        public string StreetWithNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}