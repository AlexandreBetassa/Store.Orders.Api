namespace Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Models
{
    public class JwtConfiguration
    {
        public string SecretJwtKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpirationInMinutes { get; set; }

        public string[] AdminRoles { get; set; }

        public string[] UserRoles { get; set; }
    }
}