using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Domain.Models.Enums;
using MarketPlace.Interfaces.IGeneric;
using Microsoft.AspNetCore.Identity;

namespace MarketPlace.Domain.Models;

public class ApplicationUser : IdentityUser<Guid>, IResultSearch
{
    public string CpfCnpj { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public DateTime DataNascimento { get; set; }
    public string Endereco { get; set; } = null!;
    public string? Endereco2 { get; set; }
    public string Cep { get; set; }
    public EnumUserType EnumUserType { get; set; }

    public UserDto UserDto()
    {
        UserDto userDto = new()
        {
            Id = Id,
            UserName = UserName,
            Email = Email
        };

        return userDto;
    }
}