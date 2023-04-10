﻿using Map360Task.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Map360Task.UI.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [MinLength(3, ErrorMessage = "İsim en az 3 karakter olmalıdır")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Lütfen sadece harf kullanın.")]
        [Column(TypeName = "jsonb")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [MinLength(3, ErrorMessage = "Soyisim en az 3 karakter olmalıdır")]
        [Column(TypeName = "jsonb")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [EmailAddress(ErrorMessage = "Lütfen bir mail adresi giriniz")]
        [Column(TypeName = "jsonb")]
        public string Email { get; set; }
        public Company? Company { get; set; }
        public Role? Role { get; set; }
    }
}
