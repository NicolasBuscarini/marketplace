using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Models.DTOs
{
    public class SignUpDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "NomeCompleto is required")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "DataNascimento is required")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Endereco is required")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Endereco2 is required")]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage = "Cep is required")]
        public int Cep { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "CPF is required")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }
    }
}
