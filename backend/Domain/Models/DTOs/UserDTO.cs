using MarketPlace.Domain.Models.Enums;

namespace MarketPlace.Domain.Models.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public EnumTypeUser TypeUserEnum { get; set; }
    }
}
