namespace MarketPlace.Domain.Models.DTOs
{
    public class SsoDTO
    {
        public string Access_token { get; set; }
        public DayOfWeek Expiration { get; set; }
        public ApplicationUser User { get; set; }

        public SsoDTO(string access_token, DateTime expiration, ApplicationUser user)
        {

            this.Access_token = access_token;
            this.Expiration = DateTime.Now.DayOfWeek;
            this.User = user;
        }
    }
}
