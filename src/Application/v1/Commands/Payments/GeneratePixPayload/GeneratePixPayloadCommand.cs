using MediatR;

namespace Fatec.Store.Orders.Application.v1.Commands.Payments.GeneratePixPayload
{
    public class GeneratePixPayloadCommand : IRequest<GeneratePixPayloadCommandResponse>
    {
        public decimal Amount { get; set; }

        public int OrderNumber { get; set; }
    }
}
