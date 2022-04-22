using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Domain.Models.DTOs
{
    public class SignUpDto
    {
        public SignUpDto(string username, string nomeCompleto, DateTime dataNascimento, string endereco, string endereco2, int cep, string email, string password, string passwordConfirm, string cpfCnpj, string phoneNumber)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            NomeCompleto = nomeCompleto ?? throw new ArgumentNullException(nameof(nomeCompleto));
            DataNascimento = dataNascimento;
            Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
            Endereco2 = endereco2 ?? throw new ArgumentNullException(nameof(endereco2));
            Cep = cep;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            PasswordConfirm = passwordConfirm ?? throw new ArgumentNullException(nameof(passwordConfirm));
            CpfCnpj = cpfCnpj ?? throw new ArgumentNullException(nameof(cpfCnpj));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        }

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

        [Required(ErrorMessage = "Cpf/Cnpj is required")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }
    }
}
