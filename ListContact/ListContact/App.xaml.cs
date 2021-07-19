using ListContact.Persistence;
using System;
using Xamarin.Forms;
using ListContact.View;
using Xamarin.Forms.Xaml;

namespace ListContact
{
    public partial class App : Application
    {
        public static SeedData Data { get; set; }

        public App()
        {
            InitializeComponent();
            Data = new SeedData();

            MainPage = new ListContact.View.ListContact();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
