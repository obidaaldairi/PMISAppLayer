using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class UpdatePassDTO
    {
        public string Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
