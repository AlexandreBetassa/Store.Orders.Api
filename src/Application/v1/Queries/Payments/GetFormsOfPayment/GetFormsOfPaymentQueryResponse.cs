namespace Fatec.Store.Orders.Application.v1.Queries.Payments.GetFormsOfPayment
{
    public class GetFormsOfPaymentQueryResponse
    {
        public IEnumerable<string> FormsOfPaymentsAllowed { get; set; }

        public IEnumerable<string> PaymentsMethodsCardAllowed { get; set; }

        public IEnumerable<int> InstallmentOptions { get; set; }
    }
}