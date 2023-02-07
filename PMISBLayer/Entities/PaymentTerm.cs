using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Entities
{
    public class PaymentTerm
    {

        public int PaymentTermId { get; set; }
        public string PaymentTermTitle { get; set; }
        public decimal PaymentTermAmount { get; set; }
        public int DeliverableId { get; set; }
        public Deliverable Deliverable { get; set; }
        public List<InvoicePaymentTarm> InvoicePaymentTarms { get; set; }
        public bool IsInvoice { get; set; } = false;
    }
}
