using System;
using Xamarin.Forms;
using PM2_EXAMEN3.Models;
using PM2_EXAMEN3.Views;
using System.IO;

namespace PM2_EXAMEN3
{
    public partial class App : Application
    {
        static BaseDatos BD;
        public static string UbicacionDB = string.Empty;

        public static BaseDatos InstanciaBD
        {
            get
            {
                if (BD == null)
                {
                    BD = new BaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "archivo.db3"));
                }
                return BD;
            }
        }

        public App(string DBlocal)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            UbicacionDB = DBlocal;
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
