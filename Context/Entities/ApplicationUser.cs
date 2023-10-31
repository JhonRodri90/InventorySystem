using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Context.Entities
{
    public class ApplicationUser : IdentityUser
    {
        //[MaxLength(80)]
        public string Names { get; set; }

        //[MaxLength(80)]
        public string Surnames { get; set; }

        //[MaxLength(200)]
        public string Address { get; set; }
        //[MaxLength(60)]
        public string City { get; set; }
        //[MaxLength(60)]
        public string Country { get; set; }

        [NotMapped]  // No se agrega a la tabla
        public string Role { get; set; }
    }
}
