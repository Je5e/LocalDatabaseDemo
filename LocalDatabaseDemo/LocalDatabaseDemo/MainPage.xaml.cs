using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace LocalDatabaseDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadCategories();
        }

        private void BtnAddCategory_Clicked(object sender, EventArgs e)
        {
            Category NewCategory = new Category
            {
                CategoryName = nameEntry.Text,
                Description = descriptionEntry.Text
            };

            //  Registrar en la tabla Categories

            // Obtener la ruta del archivo de la base de datos.
            string DBFilePath =
                Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData), 
                "NewDB.db3");
            // Utilizar Database class
            Database Database = new Database(DBFilePath);
          int Result =  Database.InsertCategory(NewCategory);
            if (Result > 0)
            {
                DisplayAlert
                    ("Registro", $"CategoryID: {NewCategory.CategoryID}", "Ok");
            }

            LoadCategories();
        }

        private void LoadCategories()
        {
            // Obtener la ruta del archivo de la base de datos.
            string DBFilePath =
                Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData),
                "NewDB.db3");

            Database Database = new Database(DBFilePath);

            List<Category> Categories = new List<Category>();
            Categories = Database.GetCategories();

            listViewCategories.ItemsSource = Categories;
        }
    }
}
