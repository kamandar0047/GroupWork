using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Team_Work.Models
{
    public class AppUser:IdentityUser
    {[Required,StringLength(100)]
        public string  Fullname { get; set; }
    }
}
