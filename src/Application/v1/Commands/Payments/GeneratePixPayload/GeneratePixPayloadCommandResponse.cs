namespace Fatec.Store.Orders.Application.v1.Commands.Payments.GeneratePixPayload
{
    public class GeneratePixPayloadCommandResponse
    {
        public string PixPayload { get; set; }

        public string PixQrCode { get; set; }
    }
}