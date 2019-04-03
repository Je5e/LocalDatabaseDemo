using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LocalDatabaseDemo
{
    public partial class App : Application
    {
        // Centralizar el acceso a datos?
        public static Database DatabaseNorthWind;

       
        public App()
        {
            string DBFilePath =
                Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData),
                "NewDB.db3");
            DatabaseNorthWind = new Database(DBFilePath);

            InitializeComponent();
            
            MainPage = new UpdatePage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
