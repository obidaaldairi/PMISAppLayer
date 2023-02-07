using PMISBLayer.EditeCustomValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class UpdateDeliverableDTO
    {
        public int DeliverableId { get; set; }
        public string DeliverableDescription { get; set; }
        [EDeliverableStartDate]
        public DateTime DeliStartDate { get; set; }
        [EDeliverableEndDate]
        public DateTime DeliEndDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
