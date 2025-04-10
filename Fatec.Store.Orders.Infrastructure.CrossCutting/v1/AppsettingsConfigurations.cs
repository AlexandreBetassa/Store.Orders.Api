using Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Models;

namespace Fatec.Store.Orders.Infrastructure.CrossCutting.v1
{
    public class AppsettingsConfigurations
    {
        public JwtConfiguration JwtConfiguration { get; set; }

        public string Database { get; set; }
    }
}