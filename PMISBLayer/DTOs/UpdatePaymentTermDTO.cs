using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class UpdatePaymentTermDTO
    {
        public int PaymentTermId { get; set; }
        public string PaymentTermTitle { get; set; }
        public decimal PaymentTermAmount { get; set; }
        public int DeliverableId { get; set; }
    }
}
