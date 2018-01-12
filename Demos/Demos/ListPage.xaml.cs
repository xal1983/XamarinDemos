using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();

            //var lst = new List<ItemLista>();
            //for (var i = 0; i< 100; i++)
            //    lst.Add(new ItemLista() { ID = i, Descripcion = $"Item {i}" });

            //lst1.ItemsSource = lst;
            lst1.ItemSelected += Lst1_ItemSelected;

            btnLoad.Clicked += BtnLoad_Clicked;
        }

        private async void BtnLoad_Clicked(object sender, EventArgs e)
        {
            try
            {
                var cli = new HttpClient(new NativeMessageHandler());
                cli.BaseAddress = new Uri("https://swapi.co/api/");
                var result = await cli.GetStringAsync("planets");
                var data = JsonConvert.DeserializeObject<ListResult<Planet>>(result);
                lst1.ItemsSource = data.results;
            }
            catch (Exception ex)
            {
                await DisplayAlert("error", ex.Message, "OK");
            }
        }

        private void Lst1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var itm = e.SelectedItem as Planet;
            //DisplayAlert("Seleccionado:", itm.name, "OK");
            Navigation.PushAsync(new PlanetDetailsPage(itm));

            lst1.SelectedItem = null;

        }

        void btnprueba_clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            var itm = (ItemLista)b.Parent.BindingContext;

            DisplayAlert("prueba", "prueba", "ok");

        }
    }
}