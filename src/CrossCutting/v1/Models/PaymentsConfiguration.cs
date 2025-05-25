namespace Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Models
{
    public class PaymentsConfiguration
    {
        public IEnumerable<string> FormsOfPaymentsAllowed { get; set; }

        public IEnumerable<string> PaymentsMethodsCardAllowed { get; set; }

        public IEnumerable<int> InstallmentOptions { get; set; }

        public PixConfigurations PixConfiguration { get; set; }
    }
}
