using System;
using System.Threading.Tasks;
using AcdimaStore.Services;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(AcdimaStore.Droid.Services.ScanningService))]
namespace AcdimaStore.Droid.Services
{

    class ScanningService : ICrossScanning
    {
        public async Task<string> ScanAsync(bool flashOn)
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Bring the camera closer to the element",
                BottomText = "Touch the screen to focus",
                CancelButtonText = "Cancel",
                CameraUnsupportedMessage = "Your device does NOT support using camera"
            };


            ZXing.Result result = null;
            TimeSpan ts = new TimeSpan(0, 0, 0, 1, 0);
            Device.StartTimer(ts, () =>
            {
                if (result == null)
                {
                    scanner.AutoFocus();
                    if (flashOn)
                        scanner.Torch(flashOn);

                    return true;
                }
                return false;
            });

            var scanResult = await scanner.Scan(optionsCustom);
            if (!string.IsNullOrEmpty(scanResult.Text))
                Xamarin.Essentials.Vibration.Vibrate(150);
            return scanResult.Text;
        }
    }
}