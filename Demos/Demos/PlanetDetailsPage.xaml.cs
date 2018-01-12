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
	public partial class PlanetDetailsPage : ContentPage
	{
		public PlanetDetailsPage (Planet p)
		{
			InitializeComponent ();
            BindingContext = p;
            Title = p.name;
		}
	}
}