using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Domain.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace MarketPlace.Domain.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string CpfCnpj { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Endereco2 { get; set; }
        public int Cep { get; set; }
        public EnumUserType EnumUserType { get; set; }

        public UserDto UserDTO()
        {
            UserDto userDTO = new UserDto
            {
                Id = Id,
                UserName = UserName,
                Email = Email
            };

            return userDTO;
        }

    }
}
