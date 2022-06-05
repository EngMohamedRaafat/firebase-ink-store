using AcdimaStore.Services;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(AcdimaStore.Droid.Services.ToastMessage))]
namespace AcdimaStore.Droid.Services
{
    public class ToastMessage : ICrossToast
    {
        public void MakeText(string message, ToastDuration duration)
        {
            ToastLength toastLength = (duration == ToastDuration.Short) ? ToastLength.Short : ToastLength.Long;
            Toast.MakeText(Android.App.Application.Context, message, toastLength).Show();
        }
    }
}