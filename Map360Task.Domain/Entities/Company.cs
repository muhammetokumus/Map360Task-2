using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map360Task.Domain.Entities
{
    public class Company
    {
        [Required(ErrorMessage = "Zorunlu alan")]
        public int Id { get; set; }

        [Column(TypeName = "jsonb")]
        public string Info { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
