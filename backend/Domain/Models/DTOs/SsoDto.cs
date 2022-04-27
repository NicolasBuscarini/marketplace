namespace MarketPlace.Domain.Models.DTOs
{
    public class SsoDto
    {
        public string AccessToken { get; set; }
        public DayOfWeek Expiration { get; set; }
        public ApplicationUser User { get; set; }

        public SsoDto(string accessToken, ApplicationUser user)
        {
            this.AccessToken = accessToken;
            this.Expiration = DateTime.Now.DayOfWeek;
            this.User = user;
        }
    }
}
