using MarketPlace.Domain.Models.Enums;

namespace MarketPlace.Domain.Models.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string CpfCnpj { get; set; } = null!;
    public EnumUserType TypeUserEnum { get; set; }
}