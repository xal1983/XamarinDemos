
using Demos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContratistaListPage : ContentPage
	{
        ContratistaListVM vm;
		public ContratistaListPage ()
		{
			InitializeComponent ();

            BindingContext = vm = new ContratistaListVM();


		}

        //protected async void ongetdata(object sender , EventArgs e)
        //{
        //    try
        //    {
        //        var datos = await ServerLink.GetDataAsync<List<Models.ContratistaModel>>("Contratista");
        //        lst1.ItemsSource = datos;
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        await DisplayAlert("Error", ex.Message,"OK");
        //    }

        //}
    }
}