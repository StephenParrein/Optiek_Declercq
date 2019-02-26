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
    public class InvoiceRule
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public virtual Invoice GetInvoice { get; set; }
    }
}
