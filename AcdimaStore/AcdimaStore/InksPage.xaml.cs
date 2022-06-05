using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcdimaStore
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InksPage : ContentPage
	{
		public InksPage ()
		{
			InitializeComponent ();
		}

        private void SaveButton_Clicked(object sender, EventArgs e)
        {

        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}