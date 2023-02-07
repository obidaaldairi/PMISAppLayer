using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class UpdateInvoiceDTO
    {
        public int InvoiceId { get; set; }
        public string InvoiceTitle { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<int> PaymentTermIds { get; set; }
    }
}
