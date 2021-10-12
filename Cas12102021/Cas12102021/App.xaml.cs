using Cas12102021.Services;
using Cas12102021.Vues;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cas12102021
{
    public partial class App : Application
    {
        static GestionDataBase database;

        public App()
        {
            InitializeComponent();

            MainPage = new ClientVue();
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

        public static GestionDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new GestionDataBase();
                }
                return database;
            }
        }
    }
}
