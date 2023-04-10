using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map360Task.Domain.Entities
{
    public class User
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int CompanyId { get; set; }

        [Column(TypeName = "jsonb")]
        public string Info { get; set; }
        public Company? Company { get; set; }
        public Role? Role { get; set; }

    }
}
