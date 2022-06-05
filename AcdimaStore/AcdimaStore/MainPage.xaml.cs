using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AcdimaStore
{
    public partial class MainPage : ContentPage
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "mz5WtWQcW9FoMMazxFfr0tQXXf75X2uyex4nnmuT",
            BasePath = "https://acdimastore.firebaseio.com/"
        };
        IFirebaseClient client;

        public MainPage()
        {
            InitializeComponent();
        }
        protected override /*async*/ void OnAppearing()
        {
            base.OnAppearing();

            client = new FirebaseClient(config);

            if (client != null)
                DependencyService.Get<Services.ICrossToast>().MakeText("Firebase connection is established", Services.ToastDuration.Short);
        }

        private async void TestBtn_Clicked(object sender, EventArgs e)
        {
            var ink = new Ink
            {
                BarcodeID = "5",
                Name = "933XL",
                color = InkColor.Cyan,
                NumberOfPages = 8888,
                Quantity = 3,
                AlertLevel = AlertLevel.Severe,
                AllowThreat = true
            };
            SetResponse response = await client.SetAsync("Inks/" + ink.BarcodeID, ink);
            Ink result = response.ResultAs<Ink>();

            await DisplayAlert("Result", "Data Inserted " + result.BarcodeID, "OK");
        }

        private async void RetriveBtn_Clicked(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("Inks/");
            JObject result = response.ResultAs<JObject>();

            List<Ink> inks = new List<Ink>();
            foreach (JProperty property in result.Properties())
            {
                Console.WriteLine(property.Name + " - " + property.Value);

                Ink ink = (Ink)result[property.Name];
                inks.Add(ink);
            }

            InksListView.ItemsSource = inks;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = Xamarin.Forms.DependencyService.Get<Services.ICrossScanning>();
                var scanningResult = await scanner.ScanAsync(false);
                if (!string.IsNullOrEmpty(scanningResult))
                {
                    await Navigation.PushAsync(new InksPage());
                }
                else
                { }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }
    }
}
