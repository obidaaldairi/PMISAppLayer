using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class InsertPaymentTermDTO
    {
        public int PaymentTermId { get; set; }
        [Required]
        [Display(Name ="Title")]
        public string PaymentTermTitle { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public decimal PaymentTermAmount { get; set; }
        public int DeliverableId { get; set; }
        public int ProjectId { get; set; }
        public decimal ContractAmount { get; set; }


    }
}
