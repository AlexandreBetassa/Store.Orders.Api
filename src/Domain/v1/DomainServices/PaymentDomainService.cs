using Fatec.Store.Orders.Domain.v1.Interfaces.DomainServices;
using Fatec.Store.Orders.Domain.v1.Interfaces.ServiceClients;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Models;
using Microsoft.Extensions.Options;
using pix_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.PayloadModels;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ZXing;

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

        public byte[] GenerateQrCodeZXing(string payload)
        {
            var writer = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 300,
                    Width = 300
                }
            };

            var pixelData = writer.Write(payload);

            using var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
            Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
            bitmap.UnlockBits(bitmapData);

            using var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }
    }
}