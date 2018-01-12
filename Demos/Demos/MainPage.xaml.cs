using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demos
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            lbl1.Text = "Otro texto";

            btn1.Clicked += Btn1_Clicked;
		}

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("Prueba",$"Hola mundo!\n{txt1.Text}","OK");
            var page1 = new OtraPagina();
            Navigation.PushAsync(page1);
        }


        public class OtraPagina: ContentPage
        {
            static int x = 0;
            public OtraPagina()
            {
                Title = $"Child {++x}";
                var btn = new Button()
                {
                    Text="Abrir otra"
                };
                btn.Clicked += (s, e) => Navigation.PushAsync(new OtraPagina());

                var btn2 = new Button()
                {
                    Text = "Abrir otra modal"
                };
                btn2.Clicked += (s, e) => Navigation.PushModalAsync(new OtraPagina());
                Content = new StackLayout()
                {
                    Children =
                    {
                        new Label(){ Text="prueba" },
                        btn,
                        btn2
                    }
                };
            }
        }


    }
}
