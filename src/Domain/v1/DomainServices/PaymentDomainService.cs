using Fatec.Store.Orders.Domain.v1.Interfaces.DomainServices;
using Fatec.Store.Orders.Domain.v1.Interfaces.ServiceClients;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Models;
using Microsoft.Extensions.Options;
using pix_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.PayloadModels;
using QRCoder;


namespace Fatec.Store.Orders.Domain.v1.DomainServices
{
    public class PaymentDomainService(
        ICouponServiceClient couponServiceClient,
        IOptions<AppsettingsConfigurations> configurations) : IPaymentDomainService
    {
        private readonly ICouponServiceClient _couponServiceClient = couponServiceClient;
        private readonly PixConfigurations _pixConfigurations = configurations.Value.PaymentsConfiguration.PixConfiguration;


        public async Task<decimal> CalculateDiscountAsync(decimal originalAmount, string couponCode)
        {
            var couponResponse = await _couponServiceClient.GetCouponByCouponCodeAsync(couponCode);

            if (couponResponse.Active)
                return Convert.ToDecimal(couponResponse.Discount) / 100 * originalAmount;

            return decimal.Zero;
        }

        public async Task DebitCouponCodeAsync(string couponCode, int userId) =>
            await _couponServiceClient.DebitCouponCodeAsync(new() { CouponCode = couponCode, UserId = userId });

        public string GeneratePixPayload(string customerName, string amount)
        {
            var cobranca = new Cobranca(_chave: _pixConfigurations.PixKey);
            var payload = cobranca.ToPayload(_pixConfigurations.TxId, new Merchant(customerName, _pixConfigurations.City));

            payload.Amount = amount;
            payload.Description = _pixConfigurations.Description;
            var stringToQrCode = payload.GenerateStringToQrCode();

            return stringToQrCode;
        }


        public byte[] GenerateQrCode(string payload)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeImage = qrCode.GetGraphic(20);

            return qrCodeImage;
        }
    }
}
