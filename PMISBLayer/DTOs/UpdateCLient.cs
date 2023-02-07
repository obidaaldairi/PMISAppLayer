using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class UpdateCLient
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientEmail { get; set; }
        public string Address { get; set; }

    }
}
