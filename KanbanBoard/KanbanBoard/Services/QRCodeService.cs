using QRCoder;

namespace KanbanBoard.Services
{
    public class QRCodeService
    {
        // generator is injected using constructor injection for loose coupling
        // the class should not e responsible for setting up its dependencies, they should be provided
        private readonly QRCodeGenerator _generator;
        public QRCodeService(QRCodeGenerator generator)
        {
            _generator = generator;
        }

        public string GetQRCodeAsBase64(string textToEncode)
        {
            QRCodeData qrCodeData = _generator.CreateQrCode(textToEncode, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            return Convert.ToBase64String(qrCode.GetGraphic(4));
        }

    }
}
