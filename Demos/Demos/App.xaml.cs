﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Demos
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            var mp = new Demos.MainPage();

            //MainPage = new NavigationPage(mp);

            MainPage = new NavigationPage(new ListPage());
            

        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
