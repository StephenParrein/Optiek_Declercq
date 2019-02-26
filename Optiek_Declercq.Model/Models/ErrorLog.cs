using Optiek_Declercq.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optiek_Declercq.Model.Models
{
    public class ErrorLog
    {
        [Key]
        public int ID { get; set; }
        public string Message { get; set; }
    }
}
