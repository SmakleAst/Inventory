using Inventory.Service.Interfaces;
using IronBarCode;

namespace Inventory.Service.Implementations
{
    public class QrCodeService : IQrCodeService
    {
        public void QrCodeGenerator(string url)
        {
            QRCodeWriter.CreateQrCode(url, 500,
                QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng("wwwroot/QrCode/MyQR.png");
        }
    }
}
