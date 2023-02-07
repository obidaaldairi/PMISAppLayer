using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class InsertClientDTO
    {
        public int ClientId { get; set; }
        [Required]
        [Display(Name ="Client Name")]
        public string ClientName { get; set; }
        [Required]
        [Display(Name = "Client Phone")]
        public string ClientPhone { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string ClientEmail { get; set; }
        [Required]
        [Display(Name = "Adress")]
        public string Address { get; set; }

    }
}
