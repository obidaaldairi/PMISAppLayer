using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Entities
{
     public class Person : IdentityUser
     {
        public string FullName { get; set; }
    }
}
