using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Domain.Models.Enums;
using MarketPlace.Interfaces.IGeneric;
using Microsoft.AspNetCore.Identity;

namespace MarketPlace.Domain.Models;

public class ApplicationUser : IdentityUser<Guid>, IResultSearch
{
    public string CpfCnpj { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Endereco { get; set; }
    public string? Endereco2 { get; set; }
    public int Cep { get; set; }
    public EnumUserType EnumUserType { get; set; }

    public UserDto UserDTO()
    {
        UserDto userDTO = new()
        {
            Id = Id,
            UserName = UserName,
            Email = Email
        };

        return userDTO;
    }

}