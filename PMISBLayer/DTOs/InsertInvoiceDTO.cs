using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class InsertInvoiceDTO
    {
        public int ProjectId { get; set; }
        public int InvoiceId { get; set; }
        [Required]
        [Display(Name ="Title")]
        public string InvoiceTitle { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        public List<int> PaymentTermIds { get; set; }
    }
}
